using TaskManager.Domain.CommonEntities;

namespace TaskManager.Domain.Entities
{
    public class TaskItem : BaseEntity<Guid>, IAuditableProperties
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
         
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public Guid GroupId { get; set; }
        public int PriorityId { get; set; }
        public Guid BoardId { get; set; }

        public TaskType Type { get; set; } = null!;
        public TaskStatus Status { get; set; } = null!;
        public TaskGroup Group { get; set; } = null!;
        public TaskPriority Priority { get; set; } = null!;
        public Board Board { get; set; } = null!;
        public ICollection<WorkTaskNotification> TaskNotifications { get; set; } = [];
        public ICollection<SubTask> SubTasks { get; set; } = [];
        public ICollection<Permision> Permisions { get; set; } = [];
        public ICollection<TaskUpdates> TaskUpdates { get; set; } = [];
        public ICollection<TaskAttachments> TaskAttachments { get; set; } = [];

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public string? UpdatedBy { get; set; } 
    }
}  
