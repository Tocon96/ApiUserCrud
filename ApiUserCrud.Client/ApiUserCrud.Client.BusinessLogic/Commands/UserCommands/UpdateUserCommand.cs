using ApiUserCrud.Client.BusinessLogic.Services;
using ApiUserCrud.Client.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.Commands.UserCommands
{
    public class UpdateUserCommand : CommandBase
    {
        private INavigationService navigationService;
        private IModalNavigationService modalNavigationService;
        private IUserService userService;
        private UserViewModel viewModel;

        public UpdateUserCommand(INavigationService navigationService, IModalNavigationService modalNavigationService, IUserService userService, UserViewModel viewModel)
        {
            this.navigationService = navigationService;
            this.modalNavigationService = modalNavigationService;
            this.userService = userService;
            this.viewModel = viewModel;
        }
        public async override void Execute(object? parameter)
        {
            await userService.UpdateUser(viewModel.Id.GetValueOrDefault(), viewModel.FirstName, viewModel.LastName, viewModel.Email);
            navigationService.SetNavigationState(new UsersViewModel(userService, navigationService, modalNavigationService));
        }
    }
}
