using System.Collections.Generic;
using System.Threading.Tasks;
using SharePostApp.DB.Entities.Abstract;

namespace SharePostApp.DB.Repositories.Abstract
{
    public interface IRepositoryAsNoTrackingAsync<T> where T : Entity
    {
        Task<IList<T>> GetListAsNoTrackingAsync();

        Task<T> GetAsNoTrackingAsync(long id);
    }
}