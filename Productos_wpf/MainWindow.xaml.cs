using Productos_wpf.ViewModel;
using System.Windows;

namespace Productos_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow(ProductsViewModel vm)
        { 
            InitializeComponent();
            DataContext = vm;
        }

        

       

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
