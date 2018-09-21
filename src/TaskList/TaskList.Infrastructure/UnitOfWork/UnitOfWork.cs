using TaskList.Domain.Interfaces.Repositories;
using TaskList.Domain.Interfaces.UnitOfWork;
using TaskList.Infrastructure.DataContexts;
using TaskList.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private TaskListContext _context = null;
        private DbContextTransaction _transaction = null;

        private ITaskManagerRepository _taskManagerRepository = null;

        #region Methods
        public UnitOfWork()
        {
            _context = new TaskListContext();
        }

        public TaskListContext Context
        {
            get
            {
                if (_context == null) _context = new TaskListContext();
                return _context;
            }
        }

        #region Transaction
        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction != null)
            {
                if (HasTransaction())
                    _transaction.Commit();
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                if (HasTransaction())
                    _transaction.Rollback();
                _transaction.Dispose();
            }
        }

        public bool HasTransaction()
        {
            if (_transaction == null || _transaction.UnderlyingTransaction == null) return false;
            return (_transaction.UnderlyingTransaction.Connection != null);
        }
        #endregion

        #endregion

        #region Repositorys
        public ITaskManagerRepository TaskManagerRepository
        {
            get
            {
                if (_taskManagerRepository == null)
                {
                    _taskManagerRepository = new TaskManagerRepository(Context);
                }
                return _taskManagerRepository;
            }
        }

        #endregion

        #region Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DiposeObjects();
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void DiposeObjects()
        {
            if (_transaction != null)
                _transaction.Dispose();

            if (_taskManagerRepository != null)
                _taskManagerRepository.Dispose();
        }
        #endregion
    }
}

