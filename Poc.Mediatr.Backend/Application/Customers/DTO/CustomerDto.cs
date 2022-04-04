namespace Application.Customers.DTO;

public record CustomerDto(Guid Id, string FirstName, string LastName, string Street, int Number, string City);
