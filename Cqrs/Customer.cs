using cqrs_example.Entity;
using MediatR;

namespace cqrs_example.Cqrs;

public record GetCustomersQuery : IRequest<IEnumerable<Customer>>;
public record GetCustomerByIdQuery(int Id) : IRequest<Customer>;

public record UpdateCustomerCommand(Customer customer) : IRequest<Customer>;
public record DeleteCustomerCommand(int id) : IRequest<Customer>, IRequest;
public record AddCustomerCommand(Customer customer) : IRequest<Customer>;