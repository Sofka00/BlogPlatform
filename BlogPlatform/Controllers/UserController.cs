using BlogPlatform.Models.Request;
using BlogPlatform.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<UserResponse> _users = new List<UserResponse>();//списочек пользователей

        [HttpPost]
        public ActionResult<Guid> Register([FromBody] RegisterUserRequest request) 
        {
            var addedUserId = Guid.NewGuid(); // новый ид

            var newUser = new UserResponse
            {
                Id = addedUserId,
                Name = request.Name,
                Email = request.Email
            };


            _users.Add(newUser);

            return Ok(addedUserId); 
        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] LoginRequest request)
        {
            return Ok();
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = new UserResponse();
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_users);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _users.Remove(user);
            return NoContent();
        }


    }
}
