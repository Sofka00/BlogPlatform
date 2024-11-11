using BlogPlatform.Models.Request;
using BlogPlatform.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BlogPlatform.Controllers
{


    [ApiController]
    [Route("api/post")]
    public class PostsController : ControllerBase
    {
        private static List<PostResponse> _posts = new List<PostResponse>();

        [HttpPost]
        public IActionResult CreatePost(PostRequest post)
        {
            return Ok(post);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet]
        public IActionResult GetAllPost()
        {
            return Ok(_posts);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            _posts.Remove(post);
            return NoContent();
        }
    }
}

