using AutoMapper;
using BlogPlatform.BLL;
using BlogPlatform.BLL.Interfaces;
using BlogPlatform.BLL.Models;
using BlogPlatform.Mapping;
using BlogPlatform.Models.Request;
using BlogPlatform.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogPlatform.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private static List<UserResponse> _users = new List<UserResponse>();
        private Mapper _mapper;
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new APIUserMappingProfile());
                }
                );
            _mapper = new Mapper(config);
        }
        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            var response = _mapper.Map<List<UserResponse>>(users);

            return Ok(response);
        }

        [HttpGet("{id}"), Authorize]
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

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> GetLogin()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "Login") };
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddUser(UserResponse userResponse)
        {
            var userModel = _mapper.Map<UserModel>(userResponse);
            var userId = await _userService.AddUser(userModel);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, userId);
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult<Guid> Register([FromBody] RegisterUserRequest request)
        {
            var newUser = new UserModel
            {
                Id = Guid.NewGuid(),
                FullName = request.Name,
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
                CreatedAt = DateTime.UtcNow
            };

            _userService.AddUser(newUser);
            return newUser.Id;
        }

        [HttpPost("update")]
        [AllowAnonymous]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateUserRequest request)
        {
            var existingUser = await _userService.GetUserById(request.Id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            existingUser.FullName = request.FullName;
            existingUser.Login = request.Login;
            existingUser.Email = request.Email;
            existingUser.Password = request.Password;
               
            await _userService.UpdateUser(existingUser);

            return existingUser.Id;
        }



        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task <ActionResult> DeleteUser(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found."); 
            }

            await _userService.RemoveUser(user.Id);
            return NoContent(); ;

        }



    }
}



