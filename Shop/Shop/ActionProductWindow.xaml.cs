using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Shop
{
    /// <summary>
    /// Interaction logic for ActionProductWindow.xaml
    /// </summary>
    public partial class ActionProductWindow : Window
    {
        private readonly bool IsAdd = true;
        private Product Item;
        private Seller CurrentSeller;

        public ActionProductWindow(Seller current, bool isAdd, Product product = null)
        {
            InitializeComponent();
            IsAdd = isAdd;
            Item = product;
            CurrentSeller = current;
        }

        private void ClearName(object sender, RoutedEventArgs e)
        {
            nameProduct.Text = String.Empty;
        }

        private void ClearPrice(object sender, RoutedEventArgs e)
        {
            priceProduct.Text = String.Empty;
        }

        private void ClearCount(object sender, RoutedEventArgs e)
        {
            countProduct.Text = String.Empty;
        }

        private async void Save(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(nameProduct.Text) || !String.IsNullOrWhiteSpace(priceProduct.Text) || !String.IsNullOrWhiteSpace(countProduct.Text))
            {
                using (var context = new ProductContext())
                {
                    var set = context.Set<Product>();
                    if (int.TryParse(priceProduct.Text, out var price))
                    {
                        MessageBox.Show("Incorrect input price!");
                        return;
                    }
                    if (int.TryParse(countProduct.Text, out var count))
                    {
                        MessageBox.Show("Incorrect input count!");
                        return;
                    }
                    if (IsAdd)
                    {
                        var product = new Product
                        {
                            Name = nameProduct.Text,
                            Price = price,
                            Count = count,
                            Provider = CurrentSeller.Name,
                            ProviderId = CurrentSeller.Id,
                            DeletedDate = null,
                            StartDay = DateTime.Now,
                        };

                        set.Add(product);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        set.Remove(Item);
                        Item.Name = nameProduct.Text;
                        Item.Price = price;
                        Item.Count = count;
                        Item.StartDay = DateTime.Now;
                        set.Add(Item);
                        await context.SaveChangesAsync();
                    }
                }
            }
            else { MessageBox.Show("Incorrect input!"); }
        }
    }
}
