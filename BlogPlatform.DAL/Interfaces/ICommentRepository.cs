using BlogPlatform.DAL.DTOs;

namespace BlogPlatform.DAL.Interfaces
{
    public interface ICommentRepository
    {
        Task<string> AddComment(Comment comment);
        Task<List<Comment>> GetAllComments();
        Task<Guid> RemoveComment(Guid id);
        Task<Guid> UpdateComment(Comment comment);
    }
}