using BlogPlatform.DAL.DTOs;
using BlogPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.DAL.Repositorys
{
    public class PostRepository : IPostRepository
    {
        private Context _context;
        public PostRepository(Context context)
        {
            _context = context;
        }

        public async Task<Guid> AddPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public async Task<Post> GetPostById(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }
        public async Task<Guid> UpdatePost(Post post)
        {
            var postToUpdate = await GetPostById(post.Id);
            postToUpdate.Title = post.Title;
            postToUpdate.Content = post.Content;
            await _context.SaveChangesAsync();
            return postToUpdate.Id;
        }

        public async Task<Guid> RemovePost(Guid id)
        {
            var postToRemove = await GetPostById(id);
            _context.Posts.Remove(postToRemove);
            await _context.SaveChangesAsync();
            return postToRemove.Id;
        }
    }
}
