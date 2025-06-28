using cqrs_example.Commands;
using cqrs_example.FakeDB;
using cqrs_example.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cqrs_example.controllers;

[Route("api/customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _mediator.Send(new GetCustomersQuery());

        return Ok(customers);
    }

    [HttpGet("{id:int}", Name = "GetCustomerById")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));

        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
    {
        var returnCustomer = await _mediator.Send(new AddCustomerCommand(customer));
        return CreatedAtRoute("GetCustomerById", new { id = returnCustomer.Id }, returnCustomer);
    }

    [HttpDelete("{id:int}", Name = "DeleteCustomerById")]
    public async Task<IActionResult> DeleteCustomerById(int id)
    {
        _mediator.Send(new DeleteCustomerCommand(id));
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
    {
        var updatedCustomer = _mediator.Send(new UpdateCustomerCommand(customer));
        return CreatedAtRoute("GetCustomerById", new { id = updatedCustomer.Id }, updatedCustomer);
    }
}