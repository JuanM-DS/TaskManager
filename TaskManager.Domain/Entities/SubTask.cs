using TaskManager.Domain.CommonEntities;

namespace TaskManager.Domain.Entities
{
    public class SubTask : BaseEntity<Guid>, IAuditableProperties
    {
        public string Title { get; set; } = string.Empty;
        public string SortDescription { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        public Guid TaskId { get; set; }

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}  
