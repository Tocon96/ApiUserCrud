using ApiUserCrud.Client.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.Services
{
    public class NavigationService : INavigationService
    {
        private ViewModelBase CurrentViewModel { get; set; }

        public event Action CurrentViewModelChanged;
        public void SetNavigationState(ViewModelBase viewModel)
        {
            CurrentViewModel?.Dispose();
            CurrentViewModel = viewModel;
            OnCurrentViewModelChanged();
        }

        public ViewModelBase GetCurrentNavigationState()
        {
            return CurrentViewModel;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
