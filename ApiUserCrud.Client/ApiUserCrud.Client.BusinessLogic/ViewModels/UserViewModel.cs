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
    public class UserViewModel : ViewModelBase
    {
        private int? id;
        public int? Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private readonly IUserService userService;
        private readonly INavigationService navigationService;
        private readonly IModalNavigationService modalNavigationService;
        public ICommand NavigateUsersCancelCommand { get; }
        public ICommand ManageUserCommand { get; }

        public UserViewModel(IUserService userService, INavigationService navigationService, IModalNavigationService modalNavigationService, User user = null)
        {
            this.userService = userService;
            this.navigationService = navigationService;
            this.modalNavigationService = modalNavigationService;

            if (user != null)
            {
                this.Id = user.Id;
                this.FirstName = user.FirstName;
                this.LastName = user.LastName;
                this.Email = user.Email;
                ManageUserCommand = new UpdateUserCommand(this.navigationService, this.modalNavigationService, this.userService, this);
            }
            else
            {
                this.Id = null;
                ManageUserCommand = new AddUserCommand(this.navigationService, this.modalNavigationService, this.userService, this);
            }

            NavigateUsersCancelCommand = new NavigateUsersCancelCommand(this.navigationService, this.modalNavigationService, this.userService);
            
        }
    }
}
