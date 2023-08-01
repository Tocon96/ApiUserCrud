using ApiUserCrud.WpfUtils.Service;
using ApiUserCrud.WpfUtils.Services;
using ApiUserCrud.WpfUtils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.WpfUtils.Commands
{
    public class NavigateUsersCancelCommand : CommandBase
    {
        private INavigationService navigationService;
        private IGrpcService grpcService;
        private IModalNavigationService modalNavigationService;
        public NavigateUsersCancelCommand(INavigationService navigationService, IModalNavigationService modalNavigationService, IGrpcService grpcService) 
        {
            this.modalNavigationService = modalNavigationService;
            this.navigationService = navigationService;
            this.grpcService = grpcService;
        }
        public override void Execute(object? parameter)
        {
            navigationService.SetNavigationState(new UsersViewModel(grpcService, navigationService, modalNavigationService));
        }
    }
}