using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.WebApp.Persistence.EntityFramework.Context.Configurations
{
    public class TaskTypeConfigurations : IEntityTypeConfiguration<TaskType>
    {
        public void Configure(EntityTypeBuilder<TaskType> builder)
        {
            builder.ToTable("TaskTypes")
                .HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(200);

            #region Auditable properties
            builder.Property(x => x.Created)
                .IsRequired()
                .HasColumnType("Date");

            builder.Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Updated)
                .IsRequired(false)
                .HasColumnType("Date");

            builder.Property(x => x.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(50);
            #endregion

        }
    }
}
