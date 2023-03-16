using Productos_wpf.DataContext;
using Productos_wpf.Models;
using Productos_wpf.ViewModel.Services;
using Productos_wpf.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Productos_wpf.ViewModel
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        private readonly ProductsContext context;
        private readonly NewWindow newWindow;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand NewProductCommand { get; set; }

        private ObservableCollection<Product> _productList;
        public ObservableCollection<Product> productList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                ExecPropertyChanged(nameof(productList));
            }
        }


        public ProductsViewModel(ProductsContext context, NewWindow newWindow)
        {
            productList = new ObservableCollection<Product>(context.Products.ToList());

            NewProductCommand = new CommandHandler(NuevoProducto, EvaluarProductos);
            this.context = context;
            this.newWindow = newWindow;
        }


        bool EvaluarProductos()
        {
            return productList.Count() <= 15;
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
    }
}


