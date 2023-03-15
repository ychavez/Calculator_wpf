using Productos_wpf.DataContext;
using Productos_wpf.Handlers;
using Productos_wpf.Models;
using Productos_wpf.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Productos_wpf.ViewModel
{
    public class ProductsViewModel:  INotifyPropertyChanged
    {
        private readonly ProductsContext context;
        private readonly NewWindow newWindow;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private ObservableCollection<Product> _productList { get; set; }
        public ObservableCollection<Product> productList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                RaisePropertyChanged(nameof(productList));
            }
        }

  

        public ICommand INewWindowCommand { get; set; }

        public ICommand IEditWindowsCommand { get; set; }

        public Product SelectedProduct { get; set; }

        public ProductsViewModel(ProductsContext context, NewWindow newWindow)
        {
            productList = new ObservableCollection<Product>(context.Products.ToList());
            INewWindowCommand = new CommandHandler(ShowNewWindow, () => true);
            IEditWindowsCommand = new CommandHandler(() => MessageBox.Show($"{SelectedProduct!.Name}"),
                () => true);
            this.context = context;
            this.newWindow = newWindow;
        }

        void FillCollection() 
        {
            productList = new ObservableCollection<Product>(context.Products.ToList());

        }

         void ShowNewWindow() 
        {
            newWindow.ShowDialog();
            FillCollection();
            
        }
    }

 
}


