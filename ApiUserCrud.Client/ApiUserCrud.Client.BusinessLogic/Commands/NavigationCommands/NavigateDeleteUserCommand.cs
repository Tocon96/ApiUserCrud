using ApiUserCrud.Client.BusinessLogic.Models;
using ApiUserCrud.Client.BusinessLogic.Services;
using ApiUserCrud.Client.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.Commands.NavigationCommands
{
    public class NavigateDeleteUserCommand : CommandBase
    {
        private readonly IModalNavigationService modalNavigationService;
        private readonly INavigationService navigationService;
        private readonly IUserService userService;
        public NavigateDeleteUserCommand(INavigationService navigationService, IModalNavigationService modalNavigationService, IUserService userService) 
        {
            this.modalNavigationService = modalNavigationService;
            this.navigationService = navigationService;
            this.userService = userService;
        }
        public override void Execute(object? parameter)
        {
            User user = parameter as User;
            modalNavigationService.SetNavigationState(new DeleteUserConfirmationViewModel(navigationService, userService, modalNavigationService, user));
        }
    }
}
