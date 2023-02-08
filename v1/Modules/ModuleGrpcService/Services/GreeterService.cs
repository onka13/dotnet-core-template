using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using ModuleAdmin.IServices;

namespace ModuleGrpcService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IAdminUserBusinessLogic _adminUserBusinessLogic;
        public GreeterService(ILogger<GreeterService> logger, IAdminUserBusinessLogic adminUserBusinessLogic)
        {
            _logger = logger;
            _adminUserBusinessLogic = adminUserBusinessLogic;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name + (_adminUserBusinessLogic != null)
            });
        }
    }
}
