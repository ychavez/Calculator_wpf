using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Productos_wpf.DataContext;
using Productos_wpf.Stores;
using Productos_wpf.ViewModel;
using Productos_wpf.ViewModel.Services;
using Productos_wpf.Views;
using System;
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

            services.AddSingleton(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton(s => new NewWindow()
            {
                DataContext = s.GetRequiredService<ProductEditViewModel>()
            });

            services.AddSingleton(s => new ProductListControl()
            {
                DataContext = s.GetRequiredService<ProductsViewModel>()
            });

            services.AddSingleton<SerialReader>();

         


            services.AddSingleton<ProductsViewModel>();
            services.AddSingleton<Func<ProductsViewModel>>(s => () => s.GetRequiredService<ProductsViewModel>());
            services.AddSingleton<NavigationService<ProductsViewModel>>();

            services.AddSingleton<ProductEditViewModel>();
            services.AddSingleton<Func<ProductEditViewModel>>(s => () => s.GetRequiredService<ProductEditViewModel>());
            services.AddSingleton<NavigationService<ProductEditViewModel>>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<Func<MainViewModel>>(s => () => s.GetRequiredService<MainViewModel>());
            services.AddSingleton<NavigationService<MainViewModel>>();

            services.AddSingleton<NavigationStore>();
        }

        private void OnStartup(object sender, StartupEventArgs e) 
        {
            NavigationService<ProductsViewModel> navigationService =
                 serviceProvider.GetRequiredService<NavigationService<ProductsViewModel>>();
            
            navigationService.Navigate();

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}
