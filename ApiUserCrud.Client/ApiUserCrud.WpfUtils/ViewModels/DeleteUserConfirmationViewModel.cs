using ApiUserCrud.WpfUtils.Commands;
using ApiUserCrud.WpfUtils.Models;
using ApiUserCrud.WpfUtils.Service;
using ApiUserCrud.WpfUtils.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApiUserCrud.WpfUtils.ViewModels
{
    public class DeleteUserConfirmationViewModel : ViewModelBase
    {
        private readonly IModalNavigationService modalNavigationService;
        private readonly IGrpcService grpcService;
        private readonly INavigationService navigationService;
        public User user { get; set; }
        public ICommand CancelDeletionCommand { get; }
        public ICommand ConfirmDeletionCommand { get; }
        public DeleteUserConfirmationViewModel(INavigationService navigationService, IGrpcService grpcService, IModalNavigationService modalNavigationService, User user)
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
