using SharePostApp.DB.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using SharePostApp.INFRASTRUCTURE.DTOs;

namespace SharePostApp.INFRASTRUCTURE.Configuration.Mapper
{
    public class PostMappingConfiguration : AutoMapper.Profile
    {
        public PostMappingConfiguration()
        {
            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.User.FullName));
        }
        
    }
}
