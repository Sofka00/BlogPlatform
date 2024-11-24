using AutoMapper;
using BlogPlatform.Models.Request;
using BlogPlatform.BLL.Models;
using BlogPlatform.Models.Responses;
using BlogPlatform.DAL.DTOs;

namespace BlogPlatform.Mapping
{
    public class APIUserMappingProfile:Profile
    {
        public APIUserMappingProfile()
        {
            CreateMap<UserRequest, UserModel>();
            CreateMap<UserModel, UserResponse>();

            CreateMap<UserModel, User>(); // Из BLL в DAL
            CreateMap<User, UserModel>(); // Из DAL в BLL
            CreateMap<UserResponse, UserModel>();
          
        }
    }
}
