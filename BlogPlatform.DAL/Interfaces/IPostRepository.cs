using BlogPlatform.DAL.DTOs;

namespace BlogPlatform.DAL.Interfaces
{
    public interface IPostRepository
    {
        Task<Guid> AddPost(Post post);
        Task<Post> GetPostById(Guid id);
        Task<List<Post>> GetPosts();
        Task<Guid> RemovePost(Guid id);
        Task<Guid> UpdatePost(Post post);
    }
}