using Application.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Poc.Mediatr.Backend.Controllers;

[ApiController]
[Route("/api/v1/customers")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddCustomer(AddCustomer.Command command)
    {
        var id = await _mediator.Send(command);

        return Created("/api/v1/customers", id);
    }
}