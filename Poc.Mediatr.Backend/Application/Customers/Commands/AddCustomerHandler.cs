using Application.Transactions;
using Domain.Customers.Entities;
using Domain.Customers.Repositories;
using MediatR;

namespace Application.Customers.Commands;

public static class AddCustomer
{
    public record Command(string FirstName, string LastName, string Street, int Number, string City) : IRequest<Guid>;
    
    internal class Handler : IRequestHandler<Command, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = _unitOfWork.CustomerRepository;

        }


        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var (firstName, lastName, street, number, city) = request;

            var customer = new Customer(Guid.NewGuid(), firstName, lastName, street, number, city);

            await _customerRepository.Create(customer);
            await _unitOfWork.Commit();

            return customer.Id;
        }
    }
}