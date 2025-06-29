using cqrs_example.Cqrs;
using cqrs_example.Entity;
using cqrs_example.FakeDB;
using MediatR;

namespace cqrs_example.Handlers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
{
    private readonly FakeDB.FakeDB _fakeDb;

    public UpdateCustomerCommandHandler(FakeDB.FakeDB fakeDb)
    {
        _fakeDb = fakeDb;
    }

    public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _fakeDb.UpdateCustomerAsync(request.customer);
    }
}