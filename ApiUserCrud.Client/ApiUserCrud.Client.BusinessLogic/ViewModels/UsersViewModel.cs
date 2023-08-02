using ApiUserCrud.Client.BusinessLogic.Commands.NavigationCommands;
using ApiUserCrud.Client.BusinessLogic.Models;
using ApiUserCrud.Client.BusinessLogic.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ApiUserCrud.Client.BusinessLogic.ViewModels
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
                OnPropertyChanged(nameof(Users));
            }
        }

        private readonly IUserService userService;
        private readonly INavigationService navigationService;
        private readonly IModalNavigationService modalNavigationService;
        public ICommand NavigateAddUsersCommand { get; }
        public ICommand NavigateUpdateUserCommand { get; }
        public ICommand NavigateDeleteUserCommand { get; }
        public UsersViewModel(IUserService userService, INavigationService navigationService, IModalNavigationService modalNavigationService) 
        {
            this.navigationService = navigationService;
            this.userService = userService;
            this.modalNavigationService = modalNavigationService;

            NavigateAddUsersCommand = new NavigateAddUserCommand(this.navigationService, this.modalNavigationService, this.userService);
            NavigateUpdateUserCommand = new NavigateUpdateUserCommand(this.navigationService, this.modalNavigationService, this.userService);
            NavigateDeleteUserCommand = new NavigateDeleteUserCommand(this.navigationService, this.modalNavigationService, this.userService);

            Users = new ObservableCollection<User>();

            Task.Run(() => GetUsers());
        }

        private async Task GetUsers()
        {
            var users = await userService.GetUsers();
            Users = new ObservableCollection<User>(users);
        }
    }
} 