using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharePostApp.Core.Exceptions;
using SharePostApp.DB.Entities.Abstract;
using SharePostApp.DB.Extensions;
using SharePostApp.DB.Repositories.Abstract;

namespace SharePostApp.DB.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T>, IRepositoryAsNoTrackingAsync<T> where T : Entity
    {
        private readonly SharePostContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(SharePostContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public Task<T> GetAsync(long id)
        {
            var result = _dbSet.GetById(id);
            if (result == null) throw new MainException(ErrorCode.NotFound);

            return result;
        }

        public async Task<IList<T>> GetListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                new MainException(ErrorCode.NullException);

            await Task.FromResult(_dbSet.Update(entity));
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
                new MainException(ErrorCode.NotFound);

            await Task.FromResult(_dbSet.Remove(entity));
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new MainException(new ErrorCode("Save changes error", HttpStatusCode.Conflict));
            }
        }

        public Task<T> GetAsNoTrackingAsync(long id)
        {
            var result = _dbSet.AsNoTracking().GetById(id);
            if (result == null) throw new MainException(ErrorCode.NotFound);

            return result;
        }

        public async Task<IList<T>> GetListAsNoTrackingAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
    }
}