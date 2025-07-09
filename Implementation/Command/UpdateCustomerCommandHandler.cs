using AutoMapper;
using cqrs_example.Cqrs;
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
            //TODO: implement update
            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}