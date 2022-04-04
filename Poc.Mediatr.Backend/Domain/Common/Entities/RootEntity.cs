namespace Domain.Common.Entities;

public abstract class RootEntity : Entity
{
    private protected RootEntity()
    {
    }

    private protected RootEntity(Guid id) : base(id)
    {
    }
}