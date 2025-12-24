using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.WebApp.Persistence.EntityFramework.Context.Configurations
{
    public class ColorConfigurations : IEntityTypeConfiguration<AppColor>
    {
        public void Configure(EntityTypeBuilder<AppColor> builder)
        {
            builder.ToTable("Color")
                .HasKey(x=>x.Id);

            builder.HasIndex(x => x.Code)
                .IsUnique();

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(200);

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
        }
    }
}
