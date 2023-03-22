using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Productos_wpf.DataContext;
using Productos_wpf.Messages;
using Productos_wpf.Models;
using Productos_wpf.ViewModel.Base;
using Productos_wpf.ViewModel.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Productos_wpf.ViewModel
{
    public class ProductEditViewModel : ViewModelBase
    {
        private readonly ProductsContext productsContext;
        private readonly NavigationService<ProductsViewModel> navigationService;
        private readonly SerialReader serialReader;

        public ProductAction Action { get; set; }
        public ICommand AceptarCommand { get; set; }
        public ICommand DetenerCOM { get; set; }
        public ICommand LeerCOM { get; set; }

        bool _IsReading;
        public bool IsReading
        {
            get => _IsReading; set
            {
                _IsReading = value;
                ExecPropertyChanged(nameof(IsReading));
            }
        }


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

        public ProductEditViewModel(ProductsContext productsContext, 
            NavigationService<ProductsViewModel> navigationService, SerialReader serialReader)
        {
            this.productsContext = productsContext;
            this.navigationService = navigationService;
            this.serialReader = serialReader;
            AceptarCommand = new
                CommandHandler(SeleccionarAccion, () => true);

            DetenerCOM = new CommandHandler(() => { IsReading = false; serialReader.Close(); }, () => true);

            LeerCOM = new CommandHandler(LeerProducto, () => true);

            WeakReferenceMessenger.Default.Register<ProductMessage>(this, (r, e) =>
            {
                Action = e.Value.Item2;
                Product = e.Value.Item1;
                IsReadOnly = e.Value.Item2 == ProductAction.Eliminar;
            });
        }


        void LeerProducto() 
        {
            IsReading = true;
            serialReader.Open();
            Task.Run(() =>
            {
                while (IsReading) Product.Description = serialReader.Read();

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
            WeakReferenceMessenger.Default.Send<ProductActionMessage>(new(Action));
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
