using AutoMapper;
using cqrs_example.Cqrs;
using cqrs_example.Domain.OutputDTO;
using cqrs_example.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_example.Handlers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerOutputDTO>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;


    public GetCustomerByIdQueryHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CustomerOutputDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _dbContext.Customers.Include(c => c.CustomerMails)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (customer is null)
                throw new Exception("There is no customer with the given ID");

            return _mapper.Map<CustomerOutputDTO>(customer);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}