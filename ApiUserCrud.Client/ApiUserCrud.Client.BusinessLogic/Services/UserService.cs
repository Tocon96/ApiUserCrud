using ApiUserCrud.Client.BusinessLogic.Models;
using ApiUserCrud.Client.BusinessLogic.Utils;
using ApiUserCrud.Client.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger logger;
        public UserService(IUserRepository userRepository, ILogger logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public async Task<int> AddUser(string firstName, string lastName, string email)
        {
            try
            {
                return await userRepository.AddUser(firstName, lastName, email);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                return await userRepository.DeleteUser(id);
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
                var user = await userRepository.GetUser(id);
                User userDto = new User
                {
                    Id = id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
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
                var users = await userRepository.GetUsers();
                IList<User> userDtoList = new List<User>();
                foreach (var user in users)
                {
                    userDtoList.Add(new User
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email
                    });
                }

                return userDtoList;
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
                return await userRepository.UpdateUser(id, firstName, lastName, email);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }
    }
}
