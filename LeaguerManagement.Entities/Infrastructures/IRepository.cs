using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaguerManagement.Entities.Infrastructures
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Entities { get; }
        DbContext DbContext { get; }
        ICurrentUser CurrentUser { get; }

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindAsync(params object[] keyValues);
        Task InsertAsync(TEntity entity, bool saveChanges = true);
        Task InsertRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true);

        void Update(TEntity entity, bool saveChanges = true);
        void UpdateRange(IEnumerable<TEntity> entity, bool saveChanges = true);

        Task DeleteAsync(int id, bool saveChanges = true);
        Task DeleteAsync(TEntity entity, bool saveChanges = true);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true);
    }
}
