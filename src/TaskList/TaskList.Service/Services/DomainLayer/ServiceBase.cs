using TaskList.Domain.Interfaces.Repositories;
using TaskList.Domain.Interfaces.UnitOfWork;
using TaskList.Service.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Service.Services.DomainLayer
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        protected IUnitOfWork Session;
        private IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository, IUnitOfWork session)
        {
            this._repository = repository;
            this.Session = session;
        }

        public virtual void Add(TEntity obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Type Movement");
            try
            {
                _repository.Add(obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void AddList(IEnumerable<TEntity> obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Type Movement");
            try
            {
                _repository.AddList(obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Update(TEntity obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Type Movement");

            try
            {
                _repository.Update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateList(IEnumerable<TEntity> obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Type Movement");

            try
            {
                _repository.UpdateList(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public virtual void Remove(TEntity obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Type Movement");

            try
            {
                _repository.Remove(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<TEntity> GetAllAsNoTracking()
        {
            return _repository.GetAllAsNoTracking();
        }

        public virtual void Dispose()
        {
            Session.Dispose();
            _repository.Dispose();
        }
    }
}
