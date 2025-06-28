using cqrs_example.Commands;
using cqrs_example.FakeDB;
using MediatR;

namespace cqrs_example.Handlers;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, Customer>
{
    private readonly FakeDB.FakeDB _fakeDB;

    public AddCustomerHandler(FakeDB.FakeDB fakeDB)
    {
        _fakeDB = fakeDB;
    }

    public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        await _fakeDB.AddCustomerAsync(request.customer);
        return request.customer;
    }
}