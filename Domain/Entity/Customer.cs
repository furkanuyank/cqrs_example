using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_example.Entity;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

    virtual public ICollection<CustomerMail> CustomerMails { get; set; }
}

public class CustomerConfigurator : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.HasMany(c => c.CustomerMails).WithOne(cm => cm.Customer).HasForeignKey(cm => cm.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}