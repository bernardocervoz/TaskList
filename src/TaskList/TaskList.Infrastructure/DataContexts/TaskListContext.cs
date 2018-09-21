using TaskList.Domain.Models.Entities;
using TaskList.Infrastructure.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TaskList.Infrastructure.DataContexts
{
    public class TaskListContext : DbContext
    {
        public TaskListContext()
            : base("TaskList")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 240;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<TaskManager> TaskManagers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Remove Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            #endregion

            #region Add Entities Config

            modelBuilder.Configurations.Add(new TaskManagerConfig());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
