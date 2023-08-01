using Grpc.Core;

namespace ApiUserCrud.GrpcService.Services
{
    public interface IUserGrpcService
    {
        Task<AddUserId> AddUserService(AddUserDetails request, ServerCallContext context);
        Task<UpdateUserId> UpdateUserService(UpdateUserDetails request, ServerCallContext context);
        Task<DeleteUserConfirmation> DeleteUserService(DeleteUserId request, ServerCallContext context);
        Task<GetUserDetails> GetUserService(GetUserId request, ServerCallContext context);
        Task<GetUsersDetails> GetUsersService(Empty request, ServerCallContext context);
    }
}
