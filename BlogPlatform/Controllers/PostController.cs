using AutoMapper;
using BlogPlatform.BLL;
using BlogPlatform.BLL.Interfaces;
using BlogPlatform.BLL.Models;
using BlogPlatform.Mapping;
using BlogPlatform.Models.Request;
using BlogPlatform.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BlogPlatform.Controllers
{


    [ApiController]
    [Route("api/post")]
    public class PostsController : ControllerBase
    {
        private static List<PostResponse> _posts = new List<PostResponse>();
        private Mapper _mapper;
        private IPostServices _postService;

        public PostsController(IPostServices postService)
        {
            _postService = postService;
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new ApiPostMappingProfile());
                }
                );
            _mapper = new Mapper(config);
        }

        [HttpPost("create-post")]
        [AllowAnonymous]
        public ActionResult<Guid> AddPost([FromBody] PostRequest request)
        {

           var UserId= this.User.Claims.First(i => i.Type == "UserId").Value;

            var newPost = new PostModel
            {
                Id = Guid.NewGuid(),
                Title= request.Title,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow,
                AuthorId= UserId,
            };

            _postService.AddPost(newPost);
            return newPost.Id;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostResponse>> GetPostById(Guid id)
        {
            var user = await _postService.GetPostById(id);
            if (user == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<PostResponse>(user);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<PostRequest>>> GetPosts()
        {
            var posts = await _postService.GetAllPosts();

            var response = _mapper.Map<List<PostResponse>>(posts);

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(Guid id)
        {
            var post = await _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound($"Post with ID {id} not found.");
            }

            await _postService.RemovePost(post.Id);
            return NoContent(); ;
        }
        [HttpPost("update")]
        [AllowAnonymous]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdatePostRequest request)
        {
            var UserId = this.User.Claims.First(i => i.Type == "UserId").Value;
            var existingPost = await _postService.GetPostById(request.Id);
            if (_postService.AccessUserToUpdate(existingPost, UserId).Result)
            {
                return BadRequest("Not acceess to user");
            }
            if (existingPost == null)
            {
                return NotFound("User not found.");
            }
           
            existingPost.Title = request.Title;
            existingPost.Content = request.Content;

            await _postService.UpdatePost(existingPost);

            return existingPost.Id;
        }

    }
}

