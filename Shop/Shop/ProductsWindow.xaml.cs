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
    /// Interaction logic for ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        public Seller CurrentSeller { get; set; }
        public ProductsWindow(Seller current)
        {
            InitializeComponent();
            CurrentSeller = current;
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            var window = new ActionProductWindow(CurrentSeller, true);
            window.Show();
        }

        private void SelectProduct(object sender, SelectionChangedEventArgs e)
        {
            var selectedCells = e.AddedItems;
            foreach(var di in selectedCells)
            {
                MessageBox.Show(di.ToString());
            }
        }
    }
}
