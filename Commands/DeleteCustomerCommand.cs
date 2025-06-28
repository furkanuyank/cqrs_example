using cqrs_example.FakeDB;
using MediatR;

namespace cqrs_example.Commands;

public record DeleteCustomerCommand(int id) : IRequest<Customer>, IRequest;