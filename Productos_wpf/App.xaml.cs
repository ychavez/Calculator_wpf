using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Productos_wpf.DataContext;
using Productos_wpf.ViewModel;
using Productos_wpf.Views;
using System.Windows;

namespace Productos_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ProductsContext>
                (x=> x.UseSqlite("Data Source = Products.db"));
            services.AddSingleton<MainWindow>();
            services.AddSingleton<NewWindow>();

            services.AddTransient<ProductsViewModel>();
        }

        private void OnStartup(object sender, StartupEventArgs e) 
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}
