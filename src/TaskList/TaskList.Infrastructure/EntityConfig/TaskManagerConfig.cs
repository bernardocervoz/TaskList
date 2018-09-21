using TaskList.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace TaskList.Infrastructure.EntityConfig
{
    public class TaskManagerConfig : EntityTypeConfiguration<TaskManager>
    {
        public TaskManagerConfig()
        {
            ToTable("TaskManager");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(250)
                .IsOptional();

            Property(x => x.TaskDate)
                .IsRequired();

            Property(x => x.Status)
                .IsOptional();
        }
    }
}
