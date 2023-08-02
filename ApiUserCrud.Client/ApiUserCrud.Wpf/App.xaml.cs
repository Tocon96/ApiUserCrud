using ApiUserCrud.Client.BusinessLogic.Services;
using ApiUserCrud.Client.BusinessLogic.Utils;
using ApiUserCrud.Client.BusinessLogic.ViewModels;
using ApiUserCrud.Client.DataAccess.DataProviders;
using ApiUserCrud.Client.DataAccess.Repositories;
using ApiUserCrud.Wpf.Views;
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
            services.AddSingleton<Client.BusinessLogic.Utils.ILogger, Client.BusinessLogic.Utils.Logger>();
            services.AddSingleton<Client.DataAccess.Utils.ILogger, Client.DataAccess.Utils.Logger>();
            services.AddSingleton<IGrpcServiceProvider>(new GrpcServiceProvider(settings["localhoststring"]));
            services.AddSingleton<IUserRepository>(s => new UserRepository(s.GetRequiredService<IGrpcServiceProvider>().GetUserGrpcClient(), s.GetRequiredService<Client.DataAccess.Utils.ILogger>()));
            services.AddSingleton<IUserService, UserService>();
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
            IUserService userService = serviceProvider.GetRequiredService<IUserService>();
            IModalNavigationService modalNavigationService = serviceProvider.GetRequiredService<IModalNavigationService>();

            navigationService.SetNavigationState(new UsersViewModel(userService, navigationService, modalNavigationService));

            MainWindow = serviceProvider.GetRequiredService<MainWindow>(); 
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
