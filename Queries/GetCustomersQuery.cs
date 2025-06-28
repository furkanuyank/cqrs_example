using cqrs_example.FakeDB;
using MediatR;

namespace cqrs_example.Queries;

public record GetCustomersQuery : IRequest<IEnumerable<Customer>>;