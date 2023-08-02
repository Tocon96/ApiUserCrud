using ApiUserCrud.Client.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.Client.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<int> AddUser(string firstName, string lastName, string email);
        Task<int> UpdateUser(int id, string firstName, string lastName, string email);
        Task<bool> DeleteUser(int id);
        Task<User> GetUser(int id);
        Task<IList<User>> GetUsers();
    }
}
