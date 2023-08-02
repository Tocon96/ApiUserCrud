using ApiUserCrud.Client.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.Commands.NavigationCommands
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