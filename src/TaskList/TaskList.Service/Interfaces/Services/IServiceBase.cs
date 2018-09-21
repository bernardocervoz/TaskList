using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Service.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void AddList(IEnumerable<TEntity> obj);
        void Update(TEntity obj);
        void UpdateList(IEnumerable<TEntity> obj);
        void Remove(TEntity obj);
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllAsNoTracking();
        void Dispose();
    }
}
