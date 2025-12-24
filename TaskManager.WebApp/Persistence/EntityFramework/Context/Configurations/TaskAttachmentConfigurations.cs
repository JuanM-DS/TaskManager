using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.WebApp.Persistence.EntityFramework.Context.Configurations
{
    public class TaskAttachmentConfigurations : IEntityTypeConfiguration<TaskAttachments>
    {
        public void Configure(EntityTypeBuilder<TaskAttachments> builder)
        {
            builder.ToTable("TaskAttachments")
                .HasKey(x => x.Id);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(x => x.TaskItem)
                .WithMany()
                .HasForeignKey(x => x.TaskId);

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
