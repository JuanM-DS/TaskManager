using TaskManager.Domain.CommonEntities;

namespace TaskManager.Domain.Entities
{
    public class TaskAttachments : BaseEntity<Guid>, IAuditableProperties
    {
        public string Code { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public Guid TaskId{ get; set; } 

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}  
