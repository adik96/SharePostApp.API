using Microsoft.EntityFrameworkCore;
using SharePostApp.DB.Entities.Concrete;
using SharePostApp.DB.Repositories.Abstract;
using System.Threading.Tasks;

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

        public Task<User> GetByEmail(string email)
        {
            return _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}