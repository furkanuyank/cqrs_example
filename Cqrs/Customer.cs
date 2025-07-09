using cqrs_example.Domain.DTO;
using cqrs_example.Domain.OutputDTO;
using cqrs_example.Entity;
using MediatR;

namespace cqrs_example.Cqrs;

public record GetCustomersQuery : IRequest<IEnumerable<CustomerOutputDTO>>;

public record GetCustomerByIdQuery(int Id) : IRequest<CustomerOutputDTO>;

public record UpdateCustomerCommand(int id, CustomerInputDTO CustomerInputDto) : IRequest<CustomerOutputDTO>;

public record DeleteCustomerCommand(int id) : IRequest<CustomerOutputDTO>;

public record AddCustomerCommand(CustomerInputDTO CustomerInputDto) : IRequest<CustomerOutputDTO>;