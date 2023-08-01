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
    public class AddUserViewModel : ViewModelBase
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

        private readonly IGrpcService grpcService;
        private readonly INavigationService navigationService;
        private readonly IModalNavigationService modalNavigationService;
        public ICommand NavigateUsersCancelCommand { get; }
        public ICommand ManageUserCommand { get; }

        public AddUserViewModel(IGrpcService grpcService, INavigationService navigationService, IModalNavigationService modalNavigationService, User user = null)
        {
            this.grpcService = grpcService;
            this.navigationService = navigationService;
            this.modalNavigationService = modalNavigationService;

            if (user != null)
            {
                this.Id = user.Id;
                this.FirstName = user.FirstName;
                this.LastName = user.LastName;
                this.Email = user.Email;
                ManageUserCommand = new UpdateUserCommand(this.navigationService, this.modalNavigationService, this.grpcService, this);
            }
            else
            {
                this.Id = null;
                ManageUserCommand = new AddUserCommand(this.navigationService, this.modalNavigationService, this.grpcService, this);
            }

            NavigateUsersCancelCommand = new NavigateUsersCancelCommand(this.navigationService, this.modalNavigationService, this.grpcService);
            
        }
    }
}
