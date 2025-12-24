using TaskManager.Domain.CommonEntities;

namespace TaskManager.Domain.Entities
{
    public class UserBoard : BaseEntity<Guid>, IAuditableProperties
    {
        public Guid UserId { get; set; }
        public Guid BoardId { get; set; }
        public int BoardUserRoleId { get; set; }

        public Board Board { get; set; } = null!;
        public BoardUserRole BoardUserRole { get; set; } = null!;

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}  
