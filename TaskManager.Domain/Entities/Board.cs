using TaskManager.Domain.CommonEntities;

namespace TaskManager.Domain.Entities
{
    public class Board : BaseEntity<Guid>, IAuditableProperties
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BackgroundUrl { get; set; } = string.Empty;
        public int ColorId { get; set; }
        public Guid SpaceId { get; set; }

        public Space Space { get; set; } = null!;
        public AppColor Color { get; set; } = null!;
        public ICollection<UserBoard> UserBoards { get; set; } = [];

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}  
