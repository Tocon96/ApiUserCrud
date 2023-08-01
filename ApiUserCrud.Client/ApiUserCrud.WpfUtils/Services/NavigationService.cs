using ApiUserCrud.WpfUtils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.WpfUtils.Service
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
