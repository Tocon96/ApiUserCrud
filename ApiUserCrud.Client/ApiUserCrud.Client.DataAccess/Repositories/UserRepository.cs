using ApiUserCrud.Client.DataAccess.DataProviders;
using ApiUserCrud.Client.DataAccess.Models;
using ApiUserCrud.Client.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger logger;
        private UserGrpc.UserGrpcClient grpcClient { get; set; }
        public UserRepository(UserGrpc.UserGrpcClient grpcClient, ILogger logger)
        {
            this.grpcClient = grpcClient;
            this.logger = logger;
        }

        public async Task<int> AddUser(string firstName, string lastName, string email)
        {
            try
            {
                UserGrpcModel userGrpcModel = new UserGrpcModel
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                var reply = await grpcClient.AddUserAsync(new AddUserDetails()
                {
                    User = userGrpcModel
                });

                return reply.Id;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var reply = await grpcClient.DeleteUserAsync(new DeleteUserId()
                {
                    Id = id
                });

                return reply.Deleted;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                var reply = await grpcClient.GetUserAsync(new GetUserId()
                {
                    Id = id
                });
                var userGrpc = reply.User;

                User userDto = new User
                {
                    Id = userGrpc.Id,
                    FirstName = userGrpc.FirstName,
                    LastName = userGrpc.LastName,
                    Email = userGrpc.Email,
                };

                return userDto;

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        public async Task<IList<User>> GetUsers()
        {
            try
            {
                var reply = await grpcClient.GetUsersAsync(new Empty());
                var userGrpcList = reply.User.ToList();
                IList<User> users = new List<User>();

                foreach (var user in userGrpcList)
                {
                    User userDto = new User
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                    };

                    users.Add(userDto);
                }

                return users.ToList();

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        public async Task<int> UpdateUser(int id, string firstName, string lastName, string email)
        {
            try
            {
                UserGrpcModel userGrpcModel = new UserGrpcModel
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                var reply = await grpcClient.UpdateUserAsync(new UpdateUserDetails()
                {
                    User = userGrpcModel
                });

                return reply.Id;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }
    }
}
