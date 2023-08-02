using ApiUserCrud.Client.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.Services
{
    public interface INavigationService
    {
        public void SetNavigationState(ViewModelBase viewModel);
        public ViewModelBase GetCurrentNavigationState();
        public event Action CurrentViewModelChanged;
    }
}
