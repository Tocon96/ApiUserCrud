using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.WpfUtils.Utils
{
    public interface IGrpcServiceProvider
    {
        UserGrpc.UserGrpcClient GetUserGrpcClient();
    }
}
