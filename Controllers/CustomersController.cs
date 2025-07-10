using cqrs_example.Cqrs;
using cqrs_example.Domain.DTO;
using cqrs_example.Entity;
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

        return StatusCode(200, customers);
    }

    [HttpGet("{id:int}", Name = "GetCustomerById")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
        if (customer == null) return NotFound();

        return StatusCode(200, customer);
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] CustomerInputDTO customerInputDto)
    {
        var returnCustomer = await _mediator.Send(new AddCustomerCommand(customerInputDto));
        return StatusCode(201, returnCustomer);
    }

    [HttpDelete("{id:int}", Name = "DeleteCustomerById")]
    public async Task<IActionResult> DeleteCustomerById(int id)
    {
        var deletedCustomer = await _mediator.Send(new DeleteCustomerCommand(id));
        return StatusCode(201, deletedCustomer);
    }

    [HttpPut("{id:int}", Name = "UpdateCustomerById")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerInputDTO customerInputDto)
    {
        var updatedCustomer = await _mediator.Send(new UpdateCustomerCommand(id, customerInputDto));
        return Ok(updatedCustomer);
    }
}