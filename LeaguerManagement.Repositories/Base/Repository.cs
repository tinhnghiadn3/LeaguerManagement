using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Infrastructures;
using Microsoft.EntityFrameworkCore;

namespace LeaguerManagement.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbSet<TEntity> Entities => DbContext.Set<TEntity>();

        public ICurrentUser CurrentUser { get; set; }

        public DbContext DbContext { get; }

        public Repository(DbContext context, ICurrentUser currentUser)
        {
            CurrentUser = currentUser;
            DbContext = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await Entities.FindAsync(keyValues);
        }

        public async Task InsertAsync(TEntity entity, bool saveChanges = true)
        {
            await Entities.AddAsync(entity);

            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
        {
            foreach (var entity in entities)
            {
                await Entities.AddAsync(entity);
            }

            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public void Update(TEntity entity, bool saveChanges = true)
        {
            Entities.Update(entity);

            if (saveChanges)
            {
                DbContext.SaveChangesAsync();
            }
        }

        public void UpdateRange(IEnumerable<TEntity> entities, bool saveChanges = true)
        {
            Entities.UpdateRange(entities);
            if (saveChanges)
            {
                DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id, bool saveChanges = true)
        {
            var entity = Entities.Find(id);

            await DeleteAsync(entity);
            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(TEntity entity, bool saveChanges = true)
        {
            Entities.Remove(entity);

            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
        {
            if (entities.Any())
            {
                Entities.RemoveRange(entities);
            }

            if (saveChanges)
            {
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
