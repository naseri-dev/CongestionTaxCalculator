namespace Domain.SeedWork
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool Deleted { get; set; }
    }
}
