using Domain.Common.Repositories;
using Domain.Customers.Entities;

namespace Domain.Customers.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
}