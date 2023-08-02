using ApiUserCrud.Client.BusinessLogic.Models;

namespace ApiUserCrud.Client.BusinessLogic.Services
{
    public interface IUserService
    {
        Task<int> AddUser(string firstName, string lastName, string email);
        Task<int> UpdateUser(int id, string firstName, string lastName, string email);
        Task<bool> DeleteUser(int id);
        Task<IList<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}