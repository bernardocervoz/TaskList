using TaskList.Domain.Interfaces.Repositories;
using TaskList.Domain.Interfaces.UnitOfWork;
using TaskList.Infrastructure.Repositories;
using TaskList.Infrastructure.UnitOfWork;
using TaskList.Service.Interfaces.Services;
using TaskList.Service.Services.DomainLayer;
using Microsoft.Practices.Unity;

namespace CrossCutting.DependecyResolver.Dependency
{
    public static class DependencyRegister
    {
        public static UnityContainer Container { get; private set; }
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());

            #region TaskManager
            container.RegisterType<ITaskManagerRepository, TaskManagerRepository>(new PerResolveLifetimeManager());
            container.RegisterType<ITaskManagerService, TaskManagerService>(new PerResolveLifetimeManager());
            #endregion

            Container = container;
        }
    }
}
