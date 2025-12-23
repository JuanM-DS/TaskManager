namespace TaskManager.Domain.CommonEntities
{
    public class BaseEntity<T> where T : notnull
    {
        public T Id { get; private set; } = default!;
    }
}
