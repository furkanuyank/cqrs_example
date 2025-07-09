using System.Security.AccessControl;
using AutoMapper;
using cqrs_example.Cqrs;
using cqrs_example.Domain.OutputDTO;
using cqrs_example.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_example.Handlers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerOutputDTO>>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerOutputDTO>> Handle(GetCustomersQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var customers = await _dbContext.Customers.Include(c => c.CustomerMails).ToListAsync(cancellationToken);
            var customerOutputDTOs = new List<CustomerOutputDTO>();

            foreach (var c in customers)
            {
                customerOutputDTOs.Add(_mapper.Map<CustomerOutputDTO>(c));
            }

            return customerOutputDTOs;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}