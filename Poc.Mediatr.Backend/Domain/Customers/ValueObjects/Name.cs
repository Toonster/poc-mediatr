using Domain.Exceptions;

namespace Domain.Customers.ValueObjects;

public record Name
{
    private Name()
    {
    }

    public Name(string firstName, string lastName)
    {
        FirstName = string.IsNullOrWhiteSpace(firstName)
            ? throw new DomainException("First name can't be empty")
            : firstName;
        LastName = string.IsNullOrWhiteSpace(lastName)
            ? throw new DomainException("Last name can't be empty")
            : lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }
}