using Domain.Exceptions;

namespace Domain.Common.Entities;

public abstract class Entity
{
    private const string EmptyIdMessage = "Id can't be empty";

    private protected Entity()
    {
    }

    private protected Entity(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new DomainException(EmptyIdMessage);
        }

        Id = id;
    }

    public Guid Id { get; }
}