using ApiUserCrud.WpfUtils.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.WpfUtils.Commands
{
    public class NavigateDeleteCancelCommand : CommandBase
    {
        private readonly IModalNavigationService modalNavigationService;

        public NavigateDeleteCancelCommand(IModalNavigationService modalNavigationService)
        {
            this.modalNavigationService = modalNavigationService;
        }
        public override void Execute(object? parameter)
        {
            modalNavigationService.Close();
        }
    }
}