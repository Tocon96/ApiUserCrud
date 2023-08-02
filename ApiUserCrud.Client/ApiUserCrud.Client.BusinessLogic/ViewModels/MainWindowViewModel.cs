using ApiUserCrud.Client.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IModalNavigationService modalNavigationService;
        public ViewModelBase CurrentViewModel => navigationService.GetCurrentNavigationState();
        public ViewModelBase CurrentModalViewModel => modalNavigationService.GetCurrentModalNavigationState();
        public bool IsModalOpen => modalNavigationService.GetOpenState();
        public MainWindowViewModel(INavigationService navigationService, IModalNavigationService modalNavigationService) 
        {
            this.navigationService = navigationService;
            this.modalNavigationService = modalNavigationService;
            this.navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;
            this.modalNavigationService.CurrentModalViewModelChanged += OnCurrentModalViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnCurrentModalViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
