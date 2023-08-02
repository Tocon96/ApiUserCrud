using ApiUserCrud.Client.BusinessLogic.Services;
using ApiUserCrud.Client.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.Commands.UserCommands
{
    public class DeleteUserCommand : CommandBase
    {
        private readonly IModalNavigationService modalNavigationService;
        private readonly INavigationService navigationService;
        private readonly IUserService userService;
        private int userId;
        public DeleteUserCommand(INavigationService navigationService, IModalNavigationService modalNavigationService, IUserService userService, int userId)
        {
            this.modalNavigationService = modalNavigationService;
            this.navigationService = navigationService;
            this.userService = userService;
            this.userId = userId;
        }

        public async override void Execute(object? parameter)
        {
            await userService.DeleteUser(userId);
            modalNavigationService.Close();
            navigationService.SetNavigationState(new UsersViewModel(userService, navigationService, modalNavigationService));

        }
    }
}
