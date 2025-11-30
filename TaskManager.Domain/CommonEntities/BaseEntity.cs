namespace TaskManager.Domain.CommonEntities
{
    public class BaseEntity<T>
    {
        public required T Id { get; set; }
    }
}
