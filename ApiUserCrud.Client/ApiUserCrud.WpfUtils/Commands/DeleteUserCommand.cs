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
    public class DeleteUserCommand : CommandBase
    {
        private readonly IModalNavigationService modalNavigationService;
        private readonly INavigationService navigationService;
        private readonly IGrpcService grpcService;
        private int userId;
        public DeleteUserCommand(INavigationService navigationService, IModalNavigationService modalNavigationService, IGrpcService grpcService, int userId)
        {
            this.modalNavigationService = modalNavigationService;
            this.navigationService = navigationService;
            this.grpcService = grpcService;
            this.userId = userId;
        }

        public async override void Execute(object? parameter)
        {
            await grpcService.DeleteUser(userId);
            modalNavigationService.Close();
            navigationService.SetNavigationState(new UsersViewModel(grpcService, navigationService, modalNavigationService));

        }
    }
}
