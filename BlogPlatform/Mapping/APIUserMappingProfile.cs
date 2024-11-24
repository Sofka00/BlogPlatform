using AutoMapper;
using BlogPlatform.Models.Request;
using BlogPlatform.BLL.Models;
using BlogPlatform.Models.Responses;

namespace BlogPlatform.Mapping
{
    public class APIUserMappingProfile:Profile
    {
        public APIUserMappingProfile()
        {
            CreateMap<UserRequest, UserModel>();
            CreateMap<UserModel, UserResponse>();   
        }
    }
}
