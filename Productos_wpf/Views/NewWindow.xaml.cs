using Productos_wpf.Models;
using Productos_wpf.ViewModel;
using System.Windows;

namespace Productos_wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        private readonly ProductEditViewModel vm;

        public NewWindow(ProductEditViewModel vm)
        {      
            InitializeComponent();
            this.vm = vm;
        }


        public void ShowDialog(ProductAction accion, Product product) 
        {
            vm.Action = accion;
            vm.Product = product;
            DataContext = this.vm;
            this.ShowDialog();
        }
    }
}
