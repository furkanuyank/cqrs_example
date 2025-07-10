using AutoMapper;
using cqrs_example.Cqrs;
using cqrs_example.Domain.DTO;
using cqrs_example.Domain.OutputDTO;
using cqrs_example.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_example.Handlers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerOutputDTO>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CustomerOutputDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            //implement update
            var customer = await _dbContext.Customers.Include(c => c.CustomerMails)
                .FirstOrDefaultAsync(c => c.Id == request.id, cancellationToken);
            if (customer is null)
                throw new Exception("There is no customer with the given ID");

            _mapper.Map(request.CustomerInputDto, customer);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return _mapper.Map<CustomerOutputDTO>(customer);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}