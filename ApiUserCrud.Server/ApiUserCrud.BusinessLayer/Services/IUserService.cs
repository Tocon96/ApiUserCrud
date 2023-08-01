using ApiUserCrud.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.BusinessLayer.Services
{
    public interface IUserService
    {
        Task<int> AddUser(User user);
        Task<int> UpdateUser(User user);
        Task DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<IList<User>> GetAllUsers();

    }
}
