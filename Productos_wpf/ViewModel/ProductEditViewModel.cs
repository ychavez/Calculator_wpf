using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Productos_wpf.DataContext;
using Productos_wpf.Messages;
using Productos_wpf.Models;
using Productos_wpf.ViewModel.Base;
using Productos_wpf.ViewModel.Services;
using System.Windows.Input;

namespace Productos_wpf.ViewModel
{
    public class ProductEditViewModel : ViewModelBase
    {
        private readonly ProductsContext productsContext;
        private readonly NavigationService<ProductsViewModel> navigationService;

        private ProductAction Action { get; set; }
        public ICommand AceptarCommand { get; set; }

        public Product Product { get; set; } = new();

        public ProductEditViewModel(ProductsContext productsContext, NavigationService<ProductsViewModel> navigationService)
        {

            WeakReferenceMessenger.Default.Register<ProductMessage>(this, (r, e) =>
            {
                Action = e.Value.Item2;
                Product = e.Value.Item1;
            });

            this.productsContext = productsContext;
            this.navigationService = navigationService;
            AceptarCommand = new
                CommandHandler(SeleccionarAccion, () => true);
        }




        void SeleccionarAccion()
        {
            switch (Action)
            {
                case ProductAction.Crear:
                    CrearProducto();
                    break;
                case ProductAction.Editar:
                    EditarProducto();
                    break;
                case ProductAction.Eliminar:
                    EliminarProducto();
                    break;
            }

            navigationService.Navigate();
        }

        void EliminarProducto()
        {
            productsContext.Products.Remove(Product);
            productsContext.SaveChanges();
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
