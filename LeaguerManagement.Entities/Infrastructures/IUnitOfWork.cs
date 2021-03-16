using System;
using System.Data;
using System.Threading.Tasks;

namespace LeaguerManagement.Entities.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;

        ICurrentUser CurrentUser { get; set; }
        /// <summary>
        /// Opens a new transaction
        /// </summary>
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted);

        /// <summary>
        /// Commits the current transaction (does nothing when none exists).
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Rolls back the current transaction (does nothing when none exists).
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Saves changes to database, previously opening a transaction
        /// only when none exists. The transaction is opened with isolation
        /// level set in Unit of Work before calling this method.
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Saves changes to database, previously opening a transaction
        /// only when none exists. The transaction is opened with isolation
        /// level set in Unit of Work before calling this method.
        /// </summary>
        Task<int> SaveChangesAsync();

        void DetachAllEntries();
    }
}
