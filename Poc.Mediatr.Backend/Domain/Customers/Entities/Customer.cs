using Domain.Common.Entities;
using Domain.Customers.ValueObjects;

namespace Domain.Customers.Entities;

public class Customer : RootEntity
{
    private Customer()
    {
    }

    public Customer(Guid id, string firstName, string lastName, string street, int number, string city) : base(id)
    {
        Name = new Name(firstName, lastName);
        Address = new Address(street, number, city);
    }

    public Name Name { get; }
    public Address Address { get; }
}