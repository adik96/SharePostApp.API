using SharePostApp.DB.Entities.Concrete;
using SharePostApp.INFRASTRUCTURE.Commands.UserCommands;

namespace SharePostApp.INFRASTRUCTURE.Configuration.Mapper
{
    public class UserMappingConfiguration : AutoMapper.Profile
    {
        public UserMappingConfiguration()
        {
            CreateMap<RegisterUserCommand, User>()
                .ForMember(d => d.IsActive, map => map.MapFrom((src, dest) => true));
        }
        
    }
}
