using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Contexts;
using LeaguerManagement.Entities.Infrastructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LeaguerManagement.Repositories.Base
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private IDbContextTransaction _transaction;
		private IsolationLevel? _isolationLevel;
		private Dictionary<string, dynamic> Repositories { get; }

        public ICurrentUser CurrentUser { get; set; }

        public DbContext Context { get; private set; }

		public UnitOfWork(LeaguerManagementContext context)
		{
			Context = context;
			Repositories = new Dictionary<string, dynamic>();
		}

		public UnitOfWork(LeaguerManagementContext context, ICurrentUser currentUser) : this(context)
		{
            CurrentUser = currentUser;
        }

		private void StartNewTransactionIfNeeded()
		{
			if (_transaction != null)
			{
				return;
			}

			_transaction = _isolationLevel.HasValue ? Context.Database.BeginTransaction(_isolationLevel.Value)
													: Context.Database.BeginTransaction();
		}

		public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
		{
			_isolationLevel = isolationLevel;

			StartNewTransactionIfNeeded();
		}

		public void CommitTransaction()
		{
			/*
			 do not open transaction here, because if during the request
			 nothing was changed(only select queries were run), we don't
			 want to open and commit an empty transaction -calling SaveChanges()
			 on _transactionProvider will not send any sql to database in such case
			*/
			Context.SaveChanges();

			if (_transaction == null) return;
			_transaction.Commit();

			_transaction.Dispose();
			_transaction = null;
		}

		public void RollbackTransaction()
		{
			if (_transaction == null) return;

			_transaction.Rollback();

			_transaction.Dispose();
			_transaction = null;
		}

		public int SaveChanges()
		{
			return Context.SaveChanges();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await Context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_transaction?.Dispose();
			_transaction = null;

			Context?.Dispose();
            GC.SuppressFinalize(this);
		}

		public IRepository<TEntity> Repository<TEntity>() where TEntity : class
		{
			var type = typeof(TEntity).Name;

			lock (Repositories)
			{
				if (Repositories.ContainsKey(type))
				{
					return (IRepository<TEntity>)Repositories[type];
				}

                Repositories.Add(type, new Repository<TEntity>(Context, CurrentUser));
            }

            return Repositories[type];
		}

		public void DetachAllEntries()
		{
			foreach (var dbEntityEntry in Context.ChangeTracker.Entries().ToArray())
			{
				if (dbEntityEntry.Entity != null)
				{
					dbEntityEntry.State = EntityState.Detached;
				}
			}
		}
	}
}
