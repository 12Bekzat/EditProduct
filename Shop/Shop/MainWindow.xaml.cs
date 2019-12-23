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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillSeller("Bekzat", "bekzat@gmail.com", "123456");
        }

        private async void FillSeller(string name, string login, string password)
        {
            using(var context = new ProductContext())
            {
                var set = context.Set<Seller>();
                var seller = new Seller
                {
                    Name = name,
                    Login = login,
                    Password = password
                };
                set.Add(seller);

                var setP = context.Set<Product>();
                setP.Add(new Product
                {
                    Name = "apple",
                    Provider = name,
                    ProviderId = seller.Id,
                    StartDay = DateTime.Now,
                    DeletedDate = null,
                    Price = 100,
                    Count = 1,
                });
                
                await context.SaveChangesAsync();
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            login.Text = String.Empty;
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            var current = Find(login.Text).Result;

            var window = new ProductsWindow(current);
            window.Show();
        }

        private async Task<Seller> Find(string login)
        {
            using(var context = new ProductContext())
            {
                return await context.Sellers.FindAsync(login);
            }  
        }
    }
}
