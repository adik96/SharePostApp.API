using SharePostApp.DB.Entities.Concrete;
using System.Threading.Tasks;

namespace SharePostApp.DB.Repositories.Abstract
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
