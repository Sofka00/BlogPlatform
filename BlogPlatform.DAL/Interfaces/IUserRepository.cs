using BlogPlatform.DAL.DTOs;

namespace BlogPlatform.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task RemoveUser(Guid id);
        Task UpdateUser(User user, User userToUpdate);
    }
}