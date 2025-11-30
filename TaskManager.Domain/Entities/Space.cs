using TaskManager.Domain.CommonEntities;

namespace TaskManager.Domain.Entities
{
    public class Space : BaseEntity<Guid>, IAuditableProperties
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid UserId { get; set; }

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}  
