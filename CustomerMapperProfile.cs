using AutoMapper;
using cqrs_example.Domain.DTO;
using cqrs_example.Domain.OutputDTO;
using cqrs_example.Entity;

namespace cqrs_example;

public class CustomerMapperProfile:Profile
{
    public CustomerMapperProfile()
    {
        CreateMap<CustomerInputDTO, Customer>();
        CreateMap<CustomerMailInputDTO, CustomerMail>();

        CreateMap<Customer,CustomerOutputDTO>();
        CreateMap<CustomerMail, CustomerMailOutputDTO>();

    }
}