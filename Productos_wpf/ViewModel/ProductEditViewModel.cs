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

        public ProductAction Action { get; set; }
        public ICommand AceptarCommand { get; set; }

        bool _IsReadOnly;
        public bool IsReadOnly
        {
            get => _IsReadOnly; set
            {
                _IsReadOnly = value;
                ExecPropertyChanged(nameof(IsReadOnly));
            }
        }

        public Product Product { get; set; }

        public ProductEditViewModel(ProductsContext productsContext)
        {
            this.productsContext = productsContext;
            AceptarCommand = new
                CommandHandler(SeleccionarAccion, () => true);

            WeakReferenceMessenger.Default.Register<ProductMessage>(this, (r, e) =>
            {
                Action = e.Value.Item2;
                Product = e.Value.Item1;
                IsReadOnly = e.Value.Item2 == ProductAction.Eliminar;
            });
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
