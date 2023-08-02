using ApiUserCrud.Client.BusinessLogic.Services;
using ApiUserCrud.Client.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.Commands.NavigationCommands
{
    public class NavigateAddUserCommand : CommandBase
    {
        private readonly INavigationService navigationService;
        private readonly IModalNavigationService modalNavigationService;
        private readonly IUserService userService;
        public NavigateAddUserCommand(INavigationService navigationService, IModalNavigationService modalNavigationService, IUserService userService)
        {
            this.navigationService = navigationService;
            this.modalNavigationService = modalNavigationService;
            this.userService = userService;
        }
        public override void Execute(object? parameter)
        {
            navigationService.SetNavigationState(new UserViewModel(userService, navigationService, modalNavigationService));
        }
    }
}
