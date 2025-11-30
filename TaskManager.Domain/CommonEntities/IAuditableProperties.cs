
namespace TaskManager.Domain.CommonEntities
{
    public interface IAuditableProperties
    {
        DateTime Created { get; set; }
        string CreatedBy { get; set; }
        DateTime Updated { get; set; }
        string? UpdatedBy { get; set; }
    }
}