using cqrs_example.FakeDB;
using cqrs_example.Queries;
using MediatR;

namespace cqrs_example.Handlers;

public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
{
    private readonly FakeDB.FakeDB _fakeDB;

    public GetCustomersHandler(FakeDB.FakeDB fakeDB)
    {
        _fakeDB = fakeDB;
    }

    public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _fakeDB.GetAllCustomersAsync();
    }
}