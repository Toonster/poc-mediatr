using Application.Customers.DTO;
using MediatR;

namespace Application.Customers.Queries;

public static class GetCustomer
{
    public record Query(Guid Id) : IRequest<CustomerDto?>;
    
    internal class Handler : IRequestHandler<Query, CustomerDto?>
    {
        private readonly ICustomerQueries _customerQueries;

        public Handler(ICustomerQueries customerQueries)
        {
            _customerQueries = customerQueries;
        }

        public async Task<CustomerDto?> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _customerQueries.GetCustomerAsync(request.Id);
        }
    }
}