using cqrs_example.FakeDB;
using MediatR;

namespace cqrs_example.Commands;

public record AddCustomerCommand(Customer customer) : IRequest<Customer>;