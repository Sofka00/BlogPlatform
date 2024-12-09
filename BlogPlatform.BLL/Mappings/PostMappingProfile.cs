using AutoMapper;
using BlogPlatform.BLL.Models;
using BlogPlatform.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.BLL.Mappings
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post, PostModel>();
            CreateMap<PostModel, Post>();
        }
    }
}
