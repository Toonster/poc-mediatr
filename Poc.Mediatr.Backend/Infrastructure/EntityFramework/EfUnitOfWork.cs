using Application.Transactions;
using Domain.Customers.Repositories;
using Infrastructure.EntityFramework.Customers;

namespace Infrastructure.EntityFramework;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly MediatrPocDbContext _context;

    public EfUnitOfWork(MediatrPocDbContext context)
    {
        _context = context;
    }

    public ICustomerRepository CustomerRepository => new EfCustomerRepository(_context);

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}