using AutoMapper;
using BlogPlatform.BLL;
using BlogPlatform.BLL.Models;
using BlogPlatform.Mapping;
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
        //private static List<UserResponse> _users = new List<UserResponse>();
        private Mapper _mapper;
        private UserService _userService;

        public UsersController()
        {
            _userService = new UserService();
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new APIUserMappingProfile());
                }
                );
        }
        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            var response = _mapper.Map<List<UserResponse>>(users);

            return Ok(response);    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<UserResponse>(user);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddUser(UserResponse userResponse)
        {
            var userModel = _mapper.Map<UserModel>(userResponse);
            var userId = await _userService.AddUser(userModel);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, userId);
        }





        //[HttpPost]
        //public ActionResult<Guid> Register([FromBody] RegisterUserRequest request) 
        //{
        //    var addedUserId = Guid.NewGuid(); 

        //    var     [HttpGet]
        //    {
        //        Id = addedUserId,
        //        Name = request.Name,
        //        Email = request.Email
        //    };


        //    _users.Add(newUser);

        //    return Ok(addedUserId); 
        //}

        //[HttpPost("login")]
        //public IActionResult LogIn([FromBody] LoginRequest request)
        //{
        //    return Ok();
        //}



        //[HttpGet("{id}")]
        //public IActionResult GeUserById(int id)
        //{
        //    var user = new UserResponse();
        //    return Ok(user);
        //}

        //[HttpGet]
        //public IActionResult GetAllUsers()
        //{
        //    return Ok(_users);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteUser(Guid id)
        //{
        //    var user = _users.FirstOrDefault(u => u.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    _users.Remove(user);
        //    return NoContent();
        //}


    }
}
