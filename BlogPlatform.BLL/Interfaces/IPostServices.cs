using BlogPlatform.BLL.Models;

namespace BlogPlatform.BLL.Interfaces
{
    public interface IPostServices
    {
        Task<Guid> AddPost(PostModel post);
        Task<List<PostModel>> GetAllPosts();
        Task<PostModel> GetPostById(Guid id);
        Task RemovePost (Guid id);
        Task UpdatePost(PostModel postModel);
    }
}