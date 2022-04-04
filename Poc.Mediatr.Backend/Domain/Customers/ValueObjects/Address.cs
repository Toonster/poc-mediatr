using Domain.Exceptions;

namespace Domain.Customers.ValueObjects;

public class Address
{
    private Address()
    {
    }

    public Address(string street, int number, string city)
    {
        Street = string.IsNullOrWhiteSpace(street) ? throw new DomainException("Street can't be empty") : street;
        Number = number;
        City = string.IsNullOrWhiteSpace(city) ? throw new DomainException("City can't be empty") : city;
    }

    public string Street { get; }
    public int Number { get; }
    public string City { get; }
}