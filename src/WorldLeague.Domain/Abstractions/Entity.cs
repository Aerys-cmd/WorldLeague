namespace WorldLeague.Domain.Abstractions;

public class Entity
{
    public Guid Id { get; private set; }

    public Entity(Guid id)
    {
        Id = id;
    }

    public Entity()
    {
        Id = Guid.NewGuid();
    }
}
