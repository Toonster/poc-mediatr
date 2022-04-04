using Domain.Customers.Repositories;

namespace Application.Transactions;

public interface IUnitOfWork
{
    Task Commit();
    ICustomerRepository CustomerRepository { get; }

}