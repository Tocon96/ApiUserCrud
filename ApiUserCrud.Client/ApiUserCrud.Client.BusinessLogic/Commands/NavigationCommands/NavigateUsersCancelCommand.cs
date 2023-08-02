using ApiUserCrud.Client.BusinessLogic.Services;
using ApiUserCrud.Client.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.Commands.NavigationCommands
{
    public class NavigateUsersCancelCommand : CommandBase
    {
        private INavigationService navigationService;
        private IUserService userService;
        private IModalNavigationService modalNavigationService;
        public NavigateUsersCancelCommand(INavigationService navigationService, IModalNavigationService modalNavigationService, IUserService userService) 
        {
            this.modalNavigationService = modalNavigationService;
            this.navigationService = navigationService;
            this.userService = userService;
        }
        public override void Execute(object? parameter)
        {
            navigationService.SetNavigationState(new UsersViewModel(userService, navigationService, modalNavigationService));
        }
    }
}