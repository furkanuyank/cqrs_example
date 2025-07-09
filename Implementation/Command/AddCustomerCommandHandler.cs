using AutoMapper;
using cqrs_example.Cqrs;
using cqrs_example.Domain.DTO;
using cqrs_example.Domain.OutputDTO;
using cqrs_example.Entity;
using MediatR;

namespace cqrs_example.Handlers;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CustomerOutputDTO>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public AddCustomerCommandHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CustomerOutputDTO> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = _mapper.Map<Customer>(request.CustomerInputDto);
            await _dbContext.Customers.AddAsync(customer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var outputCustomer = _mapper.Map<CustomerOutputDTO>(customer);
            return outputCustomer;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}