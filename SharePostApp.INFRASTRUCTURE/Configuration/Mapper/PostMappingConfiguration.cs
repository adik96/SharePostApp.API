using SharePostApp.DB.Entities.Concrete;
using SharePostApp.INFRASTRUCTURE.Commands.PostCommands;
using SharePostApp.INFRASTRUCTURE.DTOs;

namespace SharePostApp.INFRASTRUCTURE.Configuration.Mapper
{
    public class PostMappingConfiguration : AutoMapper.Profile
    {
        public PostMappingConfiguration()
        {
            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.User.FullName));

            CreateMap<AddPostCommand, Post>();

            CreateMap<UpdatePostCommand, Post>()
                .ForMember(dest => dest.Id, opts => opts.Ignore());
        }
        
    }
}
