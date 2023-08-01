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
    public class UpdateUserCommand : CommandBase
    {
        private INavigationService navigationService;
        private IModalNavigationService modalNavigationService;
        private IGrpcService grpcService;
        private AddUserViewModel viewModel;

        public UpdateUserCommand(INavigationService navigationService, IModalNavigationService modalNavigationService, IGrpcService grpcService, AddUserViewModel viewModel)
        {
            this.navigationService = navigationService;
            this.modalNavigationService = modalNavigationService;
            this.grpcService = grpcService;
            this.viewModel = viewModel;
        }
        public async override void Execute(object? parameter)
        {
            await grpcService.UpdateUser(viewModel.Id.GetValueOrDefault(), viewModel.FirstName, viewModel.LastName, viewModel.Email);
            navigationService.SetNavigationState(new UsersViewModel(grpcService, navigationService, modalNavigationService));
        }
    }
}
