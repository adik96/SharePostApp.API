using SharePostApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePostApp.DB.Repositories.Abstract
{
    public interface IBaseRepository<T> : IRepository where T : Entity
    {
        Task<IList<T>> GetListAsync();

        IQueryable<T> GetQueryable();

        Task<T> GetAsync(long id);

        Task UpdateAsync(T entity);

        Task AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task SaveChangesAsync();
    }
}
