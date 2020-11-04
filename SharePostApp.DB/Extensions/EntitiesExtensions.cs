using Microsoft.EntityFrameworkCore;
using SharePostApp.Core.Exceptions;
using SharePostApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePostApp.DB.Extensions
{
    public static class EntitiesExtensions
    {
        public static async Task<T> GetById<T>(this IQueryable<T> query, long id) where T : Entity
        {
            var entity = await query.SingleOrDefaultAsync(e => e.Id == id);

            if (entity == null)
                throw new MainException(ErrorCode.NotFound, $"{typeof(T).Name} does not exist");

            return entity;
        }
    }
}
