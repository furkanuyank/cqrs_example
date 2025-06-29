using cqrs_example.Cqrs;
using MediatR;

namespace cqrs_example.Handlers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly FakeDB.FakeDB _fakeDB;

    public DeleteCustomerCommandHandler(FakeDB.FakeDB fakeDB)
    {
        _fakeDB = fakeDB;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await _fakeDB.DeleteCustomerById(request.id);
    }
}