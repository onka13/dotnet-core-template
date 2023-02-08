using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using ModuleAdmin.IServices;

namespace ModuleGrpcService
{
    public class UserService : UserGrpc.UserGrpcBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IAdminUserBusinessLogic _adminUserBusinessLogic;
        public UserService(ILogger<GreeterService> logger, IAdminUserBusinessLogic adminUserBusinessLogic)
        {
            _logger = logger;
            _adminUserBusinessLogic = adminUserBusinessLogic;
        }

        public override Task<UserResponse> GetUser(GetUserRequest request, ServerCallContext context)
        {
            var user = _adminUserBusinessLogic.GetById(request.Id).Value;
            return Task.FromResult(new UserResponse
            {
                Email = user?.Email,
                Name = user?.Name
            });
        }
    }
}
