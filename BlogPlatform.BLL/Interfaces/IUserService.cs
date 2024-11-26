using BlogPlatform.BLL.Models;

namespace BlogPlatform.BLL.Interfaces
{
    public interface IUserService
    {
        Task<Guid> AddUser(UserModel user);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(Guid id);
        Task RemoveUser(Guid id);
    }
}