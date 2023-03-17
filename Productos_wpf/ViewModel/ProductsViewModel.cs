using Productos_wpf.DataContext;
using Productos_wpf.Models;
using Productos_wpf.ViewModel.Base;
using Productos_wpf.ViewModel.Services;
using Productos_wpf.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Productos_wpf.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {

        #region campos
        private readonly ProductsContext context;
        private readonly NavigationService<ProductEditViewModel> navigationService;
        private readonly NewWindow newWindow;

        private ObservableCollection<Product> _productList;
        #endregion


        public ICommand NewProductCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand SyncProducts { get; set; }

        public ObservableCollection<Product> productList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                ExecPropertyChanged(nameof(productList));
            }
        }

        public Product SelectedProduct { get; set; }
      
        public ProductsViewModel(ProductsContext context, 
            NavigationService<ProductEditViewModel> navigationService)
        {
            productList = new ObservableCollection<Product>(context.Products.ToList());

            NewProductCommand = new NavigateCommand<ProductEditViewModel>(navigationService);
            EditProductCommand = new CommandHandler(EditarProducto, () => true);
            SyncProducts = new CommandHandler(EnviarProductos, () => true);
            
            this.context = context;
            this.navigationService = navigationService;
        }

        #region metodos

        bool EvaluarProductos()
        {
            return productList.Count() <= 15;
        }
        void EditarProducto() 
        {

          
        }

        void EnviarProductos() 
        {
            RestService restService = new RestService();

            //1 traer los productos actuales del servicio
            var products = restService.GetData<Product>("/Catalog");

            //2 traer los productos locales que no estan en el servicio
            var localProducts = context.Products.ToList().
                Where(x => !products.Any(y => y.Id == x.Id)).ToList();

            //3 mandar los nuevos productos al servicio

            Parallel.ForEach(localProducts, x =>
            {
                x.Id = 0;
                restService.Post(x, "/Catalog");

            });

        }



    
        #endregion
    }
}


