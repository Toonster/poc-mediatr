using Application.Customers.Commands;
using Application.Customers.DTO;
using Application.Customers.Queries;
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

    [HttpGet]
    public async Task<ActionResult<CustomerDto?>> GetCustomer(GetCustomer.Query query)
    {
        var customer = await _mediator.Send(query);

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddCustomer(AddCustomer.Command command)
    {
        var id = await _mediator.Send(command);

        return Created(nameof(GetCustomer), id);
    }
}