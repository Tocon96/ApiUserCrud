using ApiUserCrud.Wpf.Views;
using ApiUserCrud.WpfUtils.Service;
using ApiUserCrud.WpfUtils.Services;
using ApiUserCrud.WpfUtils.Utils;
using ApiUserCrud.WpfUtils.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Windows;

namespace ApiUserCrud.Wpf
{
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;
        public App()
        {
            var settings = ConfigurationManager.AppSettings;
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ILogger, Logger>();
            services.AddSingleton<IGrpcServiceProvider>(new GrpcServiceProvider(settings["localhoststring"]));
            services.AddSingleton<IGrpcService, GrpcService>();
            services.AddSingleton<IModalNavigationService, ModalNavigationService>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainWindowViewModel>()
            });

            serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService navigationService = serviceProvider.GetRequiredService<INavigationService>();

            IGrpcService grpcService = serviceProvider.GetRequiredService<IGrpcService>();
            IModalNavigationService modalNavigationService = serviceProvider.GetRequiredService<IModalNavigationService>();

            navigationService.SetNavigationState(new UsersViewModel(grpcService, navigationService, modalNavigationService));

            MainWindow = serviceProvider.GetRequiredService<MainWindow>(); 
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
