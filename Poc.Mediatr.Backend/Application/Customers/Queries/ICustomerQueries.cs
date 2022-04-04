using Application.Customers.DTO;

namespace Application.Customers.Queries;

public interface ICustomerQueries
{
    Task<CustomerDto?> GetCustomerAsync(Guid id);
}