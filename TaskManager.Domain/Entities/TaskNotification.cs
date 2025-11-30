using TaskManager.Domain.CommonEntities;

namespace TaskManager.Domain.Entities
{
    public class TaskNotification : BaseEntity<Guid>, IAuditableProperties
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime Date { get; set; }

        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}  
