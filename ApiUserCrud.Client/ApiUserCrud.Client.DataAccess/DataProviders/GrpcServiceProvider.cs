using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.DataAccess.DataProviders
{
    public class GrpcServiceProvider : IDisposable, IGrpcServiceProvider
    {
        private Lazy<GrpcChannel> defaultRpcChannel { get; set; }
        private string serviceUrl { get; set; }
        private bool disposedValue { get; set; }

        public GrpcServiceProvider(string serviceUrl)
        {
            this.serviceUrl = serviceUrl;
            this.defaultRpcChannel = new Lazy<GrpcChannel>(GrpcChannel.ForAddress(this.serviceUrl));
            this.disposedValue = false;
        }

        public UserGrpc.UserGrpcClient GetUserGrpcClient()
        {
            return new UserGrpc.UserGrpcClient(this.defaultRpcChannel.Value);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (this.defaultRpcChannel.IsValueCreated)
                    {
                        this.defaultRpcChannel.Value.Dispose();
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
