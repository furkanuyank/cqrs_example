using cqrs_example.FakeDB;
using MediatR;

namespace cqrs_example.Commands;

public record UpdateCustomerCommand(Customer customer) : IRequest<Customer>;