using ApiUserCrud.WpfUtils.Models;
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
    public class NavigateDeleteUserCommand : CommandBase
    {
        private readonly IModalNavigationService modalNavigationService;
        private readonly INavigationService navigationService;
        private readonly IGrpcService grpcService;
        public NavigateDeleteUserCommand(INavigationService navigationService, IModalNavigationService modalNavigationService, IGrpcService grpcService) 
        {
            this.modalNavigationService = modalNavigationService;
            this.navigationService = navigationService;
            this.grpcService = grpcService;
        }
        public override void Execute(object? parameter)
        {
            User user = parameter as User;
            modalNavigationService.SetNavigationState(new DeleteUserConfirmationViewModel(navigationService, grpcService, modalNavigationService, user));
        }
    }
}
