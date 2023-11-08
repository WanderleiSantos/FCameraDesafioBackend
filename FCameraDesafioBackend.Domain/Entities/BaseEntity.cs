namespace FCameraDesafioBackend.Domain.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    protected void Update()
    {
        UpdatedAt = DateTime.Now;
    }
}