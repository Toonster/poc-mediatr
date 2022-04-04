namespace Application.Transactions;

public interface IUnitOfWork
{
    Task Commit();
}