using Domain.Common.Entities;
using Domain.Customers.Entities;
using Domain.Customers.Repositories;

namespace Infrastructure.EntityFramework.Customers;

internal class EfCustomerRepository : EfRepository<Customer>, ICustomerRepository
{
    internal EfCustomerRepository(MediatrPocDbContext context) : base(context)
    {
    }
}