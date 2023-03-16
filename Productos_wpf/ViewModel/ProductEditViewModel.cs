using Microsoft.EntityFrameworkCore;
using Productos_wpf.DataContext;
using Productos_wpf.Models;
using Productos_wpf.ViewModel.Base;
using Productos_wpf.ViewModel.Services;
using System.Windows.Input;

namespace Productos_wpf.ViewModel
{
    public class ProductEditViewModel : ViewModelBase
    {
        private readonly ProductsContext productsContext;



        public ProductAction Action { get; set; }
        public ICommand AceptarCommand { get; set; }

        public Product Product { get; set; }

        public ProductEditViewModel(ProductsContext productsContext)
        {
            this.productsContext = productsContext;
            AceptarCommand = new
                CommandHandler(SeleccionarAccion, () => true);
        }

        void SeleccionarAccion() 
        {
            if (Action == ProductAction.Crear)
            {
                CrearProducto();
                return;
            }

            EditarProducto();
        }

        void CrearProducto() 
        {
            productsContext.Add(Product);
            productsContext.SaveChanges();
        }

        void EditarProducto() 
        {
            productsContext.Entry(Product).State = EntityState.Modified;
            productsContext.SaveChanges();
        }
    }

    
    public enum ProductAction
    {
        Crear,
        Editar,
        Eliminar
    }
}
