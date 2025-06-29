using cqrs_example.Cqrs;
using cqrs_example.Entity;
using MediatR;

namespace cqrs_example.Handlers;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
{
    private readonly FakeDB.FakeDB _fakeDB;

    public AddCustomerCommandHandler(FakeDB.FakeDB fakeDB)
    {
        _fakeDB = fakeDB;
    }

    public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        await _fakeDB.AddCustomerAsync(request.customer);
        return request.customer;
    }
}