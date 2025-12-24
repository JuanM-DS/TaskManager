using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.WebApp.Persistence.EntityFramework.Context.Configurations
{
    public class UserBoardConfigurations : IEntityTypeConfiguration<UserBoard>
    {
        public void Configure(EntityTypeBuilder<UserBoard> builder)
        {
            builder.ToTable("UserBoards")
                .HasKey(x => x.Id);

            builder.HasIndex(x=> new { x.UserId, x.BoardId })
                .IsUnique();

            builder.HasOne(x => x.Board)
                .WithMany(f => f.UserBoards)
                .HasForeignKey(x => x.BoardId);

            builder.HasOne(x => x.BoardUserRole)
                .WithMany()
                .HasForeignKey(x => x.BoardUserRoleId);

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
