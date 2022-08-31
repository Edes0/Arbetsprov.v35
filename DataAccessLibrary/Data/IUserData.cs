using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data
{
    public interface IUserData
    {
        Task<List<UserModel>> GetUsers();
        Task InsertUser(UserModel user);
        Task RemoveUser(UserModel user);
    }
}