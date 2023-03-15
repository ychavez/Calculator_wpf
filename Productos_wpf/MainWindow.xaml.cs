using Productos_wpf.DataContext;
using Productos_wpf.Views;
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
        private readonly NewWindow newWindow;

        public MainWindow(ProductsContext productsContext, NewWindow newWindow)
        {
            
            this.productsContext = productsContext;
            this.newWindow = newWindow;
            InitializeComponent();
            GetProducts();
        }

        private void GetProducts()
        {
            var products = productsContext.Products.ToList();
            ProductsDG.ItemsSource = products;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            newWindow.ShowDialog();
            GetProducts();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
