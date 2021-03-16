using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Utilities.Helper;
using Microsoft.EntityFrameworkCore;

namespace LeaguerManagement.Repositories.Extensions
{
    public static class RepositoryExtension
    {
        public static DbCommand LoadStoredProc<T>(this IRepository<T> repository, string storedProcName) where T : class
        {
            return repository.DbContext.LoadStoredProc(storedProcName);
        }

        public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate) where T : class
        {
            return await query.Where(predicate).ToListAsync();
        }

        public static async Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate) where T : class
        {
            return await query.Where(predicate).FirstOrDefaultAsync();
        }
    }
}
