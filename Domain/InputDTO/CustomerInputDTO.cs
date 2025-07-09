namespace cqrs_example.Domain.DTO;

public class CustomerInputDTO
{
    public string Name { get; set; }
    public List<CustomerMailInputDTO> CustomerMails{ get; set; }
}