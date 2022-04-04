using Application.Customers.DTO;
using Application.Customers.Queries;
using Domain.Customers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Customers;

public class EfCustomerQueries : ICustomerQueries
{
    private readonly MediatrPocDbContext _context;

    public EfCustomerQueries(MediatrPocDbContext context)
    {
        _context = context;
    }

    public Task<CustomerDto?> GetCustomerAsync(Guid id)
    {
        return _context.Set<Customer>()
            .Include(customer => customer.Address)
            .Include(customer => customer.Name)
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .Where(customer => customer.Id == id)
            .Select(customer => new CustomerDto(
                customer.Id,
                customer.Name.FirstName,
                customer.Name.LastName,
                customer.Address.Street,
                customer.Address.Number,
                customer.Address.City
            ))
            .FirstOrDefaultAsync();
    }
}