using cqrs_example.Entity;

namespace cqrs_example.Domain.OutputDTO;

public class CustomerOutputDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<CustomerMailOutputDTO> CustomerMails { get; set; }
}