using cqrs_example.Cqrs;
using cqrs_example.Entity;
using cqrs_example.FakeDB;
using MediatR;

namespace cqrs_example.Handlers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
{
    private readonly FakeDB.FakeDB _fakeDB;

    public GetCustomersQueryHandler(FakeDB.FakeDB fakeDB)
    {
        _fakeDB = fakeDB;
    }

    public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _fakeDB.GetAllCustomersAsync();
    }
}