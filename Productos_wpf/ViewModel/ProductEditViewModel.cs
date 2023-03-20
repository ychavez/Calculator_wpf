using System.Threading.Tasks;
using System.Windows;
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

      

        bool _ReadButtonVisible = true;
        bool _StopButtonVisible;
        private bool _Reading;

        private bool Reading
        {
            get => _Reading;
            set
            {
                ReadButtonVisible = !value;
                StopButtonVisible = value;
                _Reading = value;
            }
        }
        public bool ReadButtonVisible
        {
            get => _ReadButtonVisible;
            set
            {
               _ReadButtonVisible = value;
                ExecPropertyChanged(nameof(ReadButtonVisible));
            }
        }

        public bool StopButtonVisible
        {
            get => _StopButtonVisible;
            set
            {
                _StopButtonVisible = value;
                ExecPropertyChanged(nameof(StopButtonVisible));
            }
        }
        private ProductAction Action { get; set; }
        public ICommand AceptarCommand { get; set; }
        public ICommand LeerCommand { get; set; }
        public ICommand DetenerLeerCommand { get; set; }

        public Product Product { get; set; } = new();
        private SerialReader sr;
        public ProductEditViewModel(ProductsContext productsContext, NavigationService<ProductsViewModel> navigationService, SerialReader sr)
        {
            this.sr = sr; 
            WeakReferenceMessenger.Default.Register<ProductMessage>(this, (r, e) =>
            {
                Action = e.Value.Item2;
                Product = e.Value.Item1;
            });

            this.productsContext = productsContext;
            this.navigationService = navigationService;
            AceptarCommand = new  CommandHandler(SeleccionarAccion, () => true);
            LeerCommand = new CommandHandler(LeerPrecio, () => true);
            DetenerLeerCommand = new CommandHandler(()=> Reading = false, () => true);
        }


        void LeerPrecio()
        {
            Reading = true;
            Task.Run(() =>
            {
                while (Reading) Product.Description = sr.Read();
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
