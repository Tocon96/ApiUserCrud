using ApiUserCrud.WpfUtils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.WpfUtils.Services
{
    public interface IModalNavigationService
    {
        public void SetNavigationState(ViewModelBase viewModel);
        public bool GetOpenState();
        public void Close();
        public ViewModelBase GetCurrentModalNavigationState();
        public event Action CurrentModalViewModelChanged;

    }
}
