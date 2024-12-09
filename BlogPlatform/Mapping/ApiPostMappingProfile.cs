using AutoMapper;
using BlogPlatform.Models.Request;
using BlogPlatform.BLL.Models;
using BlogPlatform.Models.Responses;
using BlogPlatform.DAL.DTOs;

namespace BlogPlatform.Mapping

{
    public class ApiPostMappingProfile : Profile
    {
        public ApiPostMappingProfile()
        {
            CreateMap<PostRequest, PostModel>();
            CreateMap<PostModel, PostResponse>();

            CreateMap<PostModel, Post>(); // Из BLL в DAL
            CreateMap<Post, PostModel>(); // Из DAL в BLL
            CreateMap<PostResponse, PostModel>();
        }

    }
}
