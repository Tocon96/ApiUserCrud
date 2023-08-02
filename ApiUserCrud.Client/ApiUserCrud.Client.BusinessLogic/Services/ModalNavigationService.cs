using ApiUserCrud.Client.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.Services
{
    public class ModalNavigationService : IModalNavigationService
    {
        private ViewModelBase CurrentModalViewModel { get; set; }
        private bool IsOpen => CurrentModalViewModel != null;

        public event Action CurrentModalViewModelChanged;
        public void SetNavigationState(ViewModelBase viewModel)
        {
            CurrentModalViewModel?.Dispose();
            CurrentModalViewModel = viewModel;
            OnCurrentModalViewModelChanged();
        }

        public bool GetOpenState()
        {
            return IsOpen;
        }

        public void Close()
        {
            CurrentModalViewModel = null;
            OnCurrentModalViewModelChanged();
        }

        public ViewModelBase GetCurrentModalNavigationState()
        {
            return CurrentModalViewModel;
        }

        private void OnCurrentModalViewModelChanged()
        {
            CurrentModalViewModelChanged?.Invoke();
        }
    }
}
