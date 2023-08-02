using ApiUserCrud.Client.BusinessLogic.Commands.NavigationCommands;
using ApiUserCrud.Client.BusinessLogic.Commands.UserCommands;
using ApiUserCrud.Client.BusinessLogic.Models;
using ApiUserCrud.Client.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApiUserCrud.Client.BusinessLogic.ViewModels
{
    public class DeleteUserConfirmationViewModel : ViewModelBase
    {
        private readonly IModalNavigationService modalNavigationService;
        private readonly IUserService grpcService;
        private readonly INavigationService navigationService;
        public User user { get; set; }
        public ICommand CancelDeletionCommand { get; }
        public ICommand ConfirmDeletionCommand { get; }
        public DeleteUserConfirmationViewModel(INavigationService navigationService, IUserService grpcService, IModalNavigationService modalNavigationService, User user)
        {
            this.grpcService = grpcService;
            this.modalNavigationService = modalNavigationService;
            this.navigationService = navigationService;
            this.user = user;

            CancelDeletionCommand = new NavigateDeleteCancelCommand(this.modalNavigationService);
            ConfirmDeletionCommand = new DeleteUserCommand(this.navigationService, this.modalNavigationService, this.grpcService, this.user.Id);
        }
    }
}
