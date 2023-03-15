using Productos_wpf.DataContext;
using Productos_wpf.Models;
using Productos_wpf.ViewModel.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Productos_wpf.ViewModel
{
    public class ProductsViewModel
    {

        public ICommand NewProductCommand { get; set; }

        public List<Product> productList { get; set; }


        public ProductsViewModel(ProductsContext context)
        {
            productList = context.Products.ToList();
            NewProductCommand =
                new CommandHandler(NuevoProducto, () => true);
        }


        void NuevoProducto() 
        {
            MessageBox.Show("Nuevo producto");
        }
    }
}


