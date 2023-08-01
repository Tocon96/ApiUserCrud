using ApiUserCrud.WpfUtils.Models;

namespace ApiUserCrud.WpfUtils.Services
{
    public interface IGrpcService
    {
        Task<int> AddUser(string firstName, string lastName, string email);
        Task<int> UpdateUser(int id, string firstName, string lastName, string email);
        Task<bool> DeleteUser(int id);
        Task<IList<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}