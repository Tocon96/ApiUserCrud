using ApiUserCrud.WpfUtils.Commands;
using ApiUserCrud.WpfUtils.Models;
using ApiUserCrud.WpfUtils.Service;
using ApiUserCrud.WpfUtils.Services;
using ApiUserCrud.WpfUtils.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApiUserCrud.WpfUtils.ViewModels
{
    public class UsersViewModel : ViewModelBase
    {
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        private readonly IGrpcService grpcService;
        private readonly INavigationService navigationService;
        private readonly IModalNavigationService modalNavigationService;
        public ICommand NavigateAddUsersCommand { get; }
        public ICommand NavigateUpdateUserCommand { get; }
        public ICommand NavigateDeleteUserCommand { get; }
        public UsersViewModel(IGrpcService grpcService, INavigationService navigationService, IModalNavigationService modalNavigationService) 
        {
            this.navigationService = navigationService;
            this.grpcService = grpcService;
            this.modalNavigationService = modalNavigationService;

            NavigateAddUsersCommand = new NavigateAddUserCommand(this.navigationService, this.modalNavigationService, this.grpcService);
            NavigateUpdateUserCommand = new NavigateUpdateUserCommand(this.navigationService, this.modalNavigationService, this.grpcService);
            NavigateDeleteUserCommand = new NavigateDeleteUserCommand(this.navigationService, this.modalNavigationService, this.grpcService);

            Users = new ObservableCollection<User>();

            GetUsers();
        }

        private async void GetUsers()
        {
            var users = await grpcService.GetUsers();
            Users = new ObservableCollection<User>(users);
        }
    }
} 