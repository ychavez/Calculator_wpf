using Productos_wpf.DataContext;
using System;
using System.Linq;
using System.Windows;

namespace Productos_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProductsContext productsContext;

        public MainWindow(ProductsContext productsContext)
        {
            
            this.productsContext = productsContext;
            InitializeComponent();
            GetProducts();
        }

        private void GetProducts()
        {
            var products = productsContext.Products.ToList();
            ProductsDG.ItemsSource = products;
        }
    }
}
