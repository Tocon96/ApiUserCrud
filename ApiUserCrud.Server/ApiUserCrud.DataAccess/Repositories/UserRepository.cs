using ApiUserCrud.DataAccess.Context;
using ApiUserCrud.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDesignTimeDbContextFactory<ApiUserCrudDBContext> dbContextFactory;
        private readonly ILogger<UserRepository> logger;
        private string[] args;

        public UserRepository(IDesignTimeDbContextFactory<ApiUserCrudDBContext> dbContextFactory, ILogger<UserRepository> logger)
        {
            this.dbContextFactory = dbContextFactory;
            this.logger = logger;
            args = new string[] { };
        }

        public async Task<int> AddUser(string firstName, string lastName, string email)
        {
            using(ApiUserCrudDBContext dbContext = dbContextFactory.CreateDbContext(args))
            {
                try
                {
                    User user = new User
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email
                    };

                    dbContext.User.Add(user);
                    await dbContext.SaveChangesAsync();
                    return user.Id;
                }
                catch(Exception ex)
                {
                    logger.LogError(ex.Message);
                    throw;
                }
            }
        }

        public async Task DeleteUser(int id)
        {
            using (ApiUserCrudDBContext dbContext = dbContextFactory.CreateDbContext(args))
            {
                try
                {
                    dbContext.User.Remove(await dbContext.User.FirstOrDefaultAsync(x => x.Id == id));
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    throw;
                }
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using (ApiUserCrudDBContext dbContext = dbContextFactory.CreateDbContext(args))
            {
                try
                {
                    IEnumerable<User> users = await dbContext.User.ToListAsync();
                    return users;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    throw;
                }
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (ApiUserCrudDBContext dbContext = dbContextFactory.CreateDbContext(args))
            {
                try
                {
                    return await dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    throw;
                }
            }

        }

        public async Task<int> UpdateUser(int id, string firstName, string lastName, string email)
        {
            using (ApiUserCrudDBContext dbContext = dbContextFactory.CreateDbContext(args))
            {
                try
                {
                    User user = await dbContext.User.FirstOrDefaultAsync(x => x.Id == id);

                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.Email = email;
                    await dbContext.SaveChangesAsync();
                    return user.Id;

                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    throw;
                }
            }
        }
    }
}
