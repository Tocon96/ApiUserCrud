using ApiUserCrud.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<int> AddUser(string firstName, string lastName, string email);
        Task<int> UpdateUser(int id, string firstName, string lastName, string email);
        Task DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
