using TaskManager.Domain.CommonEntities;

namespace TaskManager.Domain.Entities
{
    public class BoardUserRole : BaseEntity<int>, IAuditableProperties
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public int ColorId { get; set; }

        public Color Color { get; set; } = null!;

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}  
