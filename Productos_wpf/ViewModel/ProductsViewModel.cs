using Productos_wpf.DataContext;
using Productos_wpf.Models;
using Productos_wpf.ViewModel.Services;
using Productos_wpf.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Productos_wpf.ViewModel
{
    public class ProductsViewModel : INotifyPropertyChanged
    {

        #region campos
        private readonly ProductsContext context;
        private readonly NewWindow newWindow;
        public event PropertyChangedEventHandler? PropertyChanged;
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
                ExecPropertyChanged(nameof(productList));
            }
        }

        public Product SelectedProduct { get; set; }
        /*
         *  1.- Crear un Viewmodel para la vista de newWindow
         *  2.- Este viewmodel tendra los metodos para dar de alta o editar (Usar operador ternario)
         *  3.- Modificar la la logica para poder recibir un enum en el show para saber si es edicion o nuevo
         *  4.- Probar
         * 
         * 
         * */

        public ProductsViewModel(ProductsContext context, NewWindow newWindow)
        {
            productList = new ObservableCollection<Product>(context.Products.ToList());

            NewProductCommand = new CommandHandler(NuevoProducto, EvaluarProductos);
            EditProductCommand = new CommandHandler(EditarProducto, () => true);

            this.context = context;
            this.newWindow = newWindow;
        }

        #region metodos

        bool EvaluarProductos()
        {
            return productList.Count() <= 15;
        }
        void EditarProducto() 
        {

            newWindow.ShowDialog(ProductAction.Editar, SelectedProduct);
        }

        void NuevoProducto()
        {
            newWindow.ShowDialog();
            productList = new ObservableCollection<Product>(context.Products.ToList());
        }

        void ExecPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is not null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}


