using AutoMapper;
using BlogPlatform.BLL.Interfaces;
using BlogPlatform.BLL.Mappings;
using BlogPlatform.BLL.Models;
using BlogPlatform.DAL.DTOs;
using BlogPlatform.DAL.Interfaces;
using BlogPlatform.DAL.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.BLL
{
    public class PostServices : IPostServices
    {
        private Mapper _mapper;
        private IPostRepository _postRepository;

        public PostServices(IPostRepository postRepository)
        {
            _postRepository = postRepository;
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new PostMappingProfile());
                });
            _mapper = new Mapper(config);
        }

        public async Task<Guid> AddPost(PostModel post)
        {
            try
            {
                var postDTO = _mapper.Map<Post>(post);

                var userId = await _postRepository.AddPost(postDTO);

                return post.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return post.Id;
            }
        }

        public async Task<List<PostModel>> GetAllPosts()
        {
            var postDTOs = await _postRepository.GetPosts();

            var posts = _mapper.Map<List<PostModel>>(postDTOs);

            return posts;
        }

        public async Task<PostModel> GetPostById(Guid id)
        {
            var postDTO = await _postRepository.GetPostById(id);
                var post =_mapper.Map<PostModel>(postDTO);
            return post;
        }

        public async Task RemovePost(Guid id)
        {
            await _postRepository.RemovePost(id);
        }

        public async Task UpdatePost(PostModel postModel)
        {
            var post = await _postRepository.GetPostById(postModel.Id);
            _mapper.Map(postModel, post);
            await _postRepository.UpdatePost(post); ;

        }
    }
}
