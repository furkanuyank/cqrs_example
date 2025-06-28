using cqrs_example.FakeDB;
using MediatR;

namespace cqrs_example.Queries;

public record GetCustomerByIdQuery(int Id) : IRequest<Customer>;