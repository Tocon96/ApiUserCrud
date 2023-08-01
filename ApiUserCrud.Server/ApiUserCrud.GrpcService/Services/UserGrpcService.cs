using ApiUserCrud.BusinessLayer.Models;
using ApiUserCrud.BusinessLayer.Services;
using ApiUserCrud.GrpcService;
using Grpc.Core;
using System.Reflection.Metadata.Ecma335;

namespace ApiUserCrud.GrpcService.Services
{
    public class UserGrpcService : UserGrpc.UserGrpcBase
    {
        private readonly ILogger<UserGrpcService> logger;
        private readonly IUserService userService;

        public UserGrpcService(ILogger<UserGrpcService> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;            
        }

        public async override Task<AddUserId> AddUser(AddUserDetails request, ServerCallContext context)
        {
            try
            {
                User user = new User
                {
                    FirstName = request.User.FirstName,
                    LastName = request.User.LastName,
                    Email = request.User.Email
                };
                int id = Task.Run(() => userService.AddUser(user)).Result;

                return new AddUserId { Id = id };
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async override Task<UpdateUserId> UpdateUser(UpdateUserDetails request, ServerCallContext context)
        {
            try
            {
                User user = new User
                {
                    Id = request.User.Id,
                    FirstName = request.User.FirstName,
                    LastName = request.User.LastName,
                    Email = request.User.Email
                };
                int id = await userService.UpdateUser(user);

                return new UpdateUserId { Id = id };
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async override Task<DeleteUserConfirmation> DeleteUser(DeleteUserId request, ServerCallContext context)
        {
            try
            {
                await userService.DeleteUser(request.Id);
                return new DeleteUserConfirmation{ Deleted = true };
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async override Task<GetUserDetails> GetUser(GetUserId request, ServerCallContext context)
        {
            try
            {
                User user = await userService.GetUserById(request.Id);
                UserGrpcModel userGrpcModel = new UserGrpcModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };

                return new GetUserDetails
                {
                    User = userGrpcModel,
                };

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async override Task<GetUsersDetails> GetUsers(Empty request, ServerCallContext context) 
        {
            try
            {
                IList<User> users = await userService.GetAllUsers();
                GetUsersDetails getUsersDetails = new GetUsersDetails();

                foreach (User user in users)
                {
                    UserGrpcModel userGrpcModel = new UserGrpcModel
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email
                    };

                    getUsersDetails.User.Add(userGrpcModel);
                }

                return getUsersDetails;

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}