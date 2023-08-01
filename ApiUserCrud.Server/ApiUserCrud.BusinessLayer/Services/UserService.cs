using ApiUserCrud.BusinessLayer.Models;
using ApiUserCrud.DataAccess.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserService> logger;
        public UserService(IUserRepository userRepository, ILogger<UserService> logger) 
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public async Task<int> AddUser(User user)
        {
            try
            {
                return await userRepository.AddUser(user.FirstName, user.LastName, user.Email);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                await userRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IList<User>> GetAllUsers()
        {
            try
            {
                var userEnumerable = await userRepository.GetAllUsers();

                IList<User> users = new List<User>();

                foreach (var user in userEnumerable)
                {
                    User newUser = new User
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email
                    };

                    users.Add(newUser);
                }

                return users;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
            
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var user = await userRepository.GetUserById(id);

                User newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };

                return newUser;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<int> UpdateUser(User user)
        {
            try
            {
                return await userRepository.UpdateUser(user.Id, user.FirstName, user.LastName, user.Email);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
