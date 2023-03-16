using Productos_wpf.DataContext;
using Productos_wpf.Models;
using Productos_wpf.ViewModel.Base;
using Productos_wpf.ViewModel.Services;
using Productos_wpf.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Productos_wpf.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {

        #region campos
        private readonly ProductsContext context;
        private ObservableCollection<Product> _productList;
        #endregion


        public ICommand NewProductCommand { get; set; }
        public ICommand EditProductCommand { get; set; }

        public ObservableCollection<Product> productList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged(nameof(productList));
            }
        }

        public Product SelectedProduct { get; set; }


        public ProductsViewModel(ProductsContext context, NavigationService<ProductEditViewModel> navigationService)
        {
            productList = new ObservableCollection<Product>(context.Products.ToList());
            EditProductCommand = new NavigateCommand<ProductEditViewModel>(navigationService);
            NewProductCommand = new CommandHandler(NuevoProducto, EvaluarProductos);
            this.context = context;
          
        }

        #region metodos

        bool EvaluarProductos()
        {
            return productList.Count() <= 15;
        }

        void NuevoProducto()
        {
          
            productList = new ObservableCollection<Product>(context.Products.ToList());
        }


        #endregion
    }
}


