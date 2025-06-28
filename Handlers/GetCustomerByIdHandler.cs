using cqrs_example.FakeDB;
using cqrs_example.Queries;
using MediatR;

namespace cqrs_example.Handlers;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    private readonly FakeDB.FakeDB _fakeDb;

    public GetCustomerByIdHandler(FakeDB.FakeDB fakeDb)
    {
        _fakeDb = fakeDb;
    }

    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _fakeDb.GetCustomerByIdAsync(request.Id);
    }
}