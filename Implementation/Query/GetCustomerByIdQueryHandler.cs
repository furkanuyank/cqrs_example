using cqrs_example.Cqrs;
using cqrs_example.Entity;
using cqrs_example.FakeDB;
using MediatR;

namespace cqrs_example.Handlers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    private readonly FakeDB.FakeDB _fakeDb;

    public GetCustomerByIdQueryHandler(FakeDB.FakeDB fakeDb)
    {
        _fakeDb = fakeDb;
    }

    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _fakeDb.GetCustomerByIdAsync(request.Id);
    }
}