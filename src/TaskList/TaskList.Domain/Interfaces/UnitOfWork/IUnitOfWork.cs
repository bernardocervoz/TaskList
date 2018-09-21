using TaskList.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        ITaskManagerRepository TaskManagerRepository { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
        bool HasTransaction();
    }
}
