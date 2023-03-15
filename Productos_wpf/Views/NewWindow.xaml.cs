using Productos_wpf.DataContext;
using Productos_wpf.Models;
using System;
using System.Linq;
using System.Windows;

namespace Productos_wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        private readonly ProductsContext productsContext;

        public NewWindow(ProductsContext productsContext)
        {      
            InitializeComponent();
            this.productsContext = productsContext;
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
        {
            e.Cancel = true;
            txtNombre.Text = "";
            txtCategoria.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            this.Visibility = Visibility.Hidden;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            var product = new Product()
            {
                Name = txtNombre.Text,
                Category = txtCategoria.Text,
                Description = txtDescripcion.Text,
                Price = Decimal.Parse(txtPrecio.Text)
            };

            productsContext.Add(product);
            productsContext.SaveChanges();
            this.Close();
        }
    }
}
