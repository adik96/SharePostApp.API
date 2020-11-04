using SharePostApp.DB.Entities.Concrete;
using SharePostApp.DB.Repositories.Abstract;

namespace SharePostApp.DB.Repositories.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SharePostContext context;

        public UserRepository(SharePostContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}