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
    public class NavigateAddUserCommand : CommandBase
    {
        private readonly INavigationService navigationService;
        private readonly IModalNavigationService modalNavigationService;
        private readonly IGrpcService grpcService;
        public NavigateAddUserCommand(INavigationService navigationService, IModalNavigationService modalNavigationService, IGrpcService grpcService)
        {
            this.navigationService = navigationService;
            this.modalNavigationService = modalNavigationService;
            this.grpcService = grpcService;
        }
        public override void Execute(object? parameter)
        {
            navigationService.SetNavigationState(new AddUserViewModel(grpcService, navigationService, modalNavigationService));
        }
    }
}
