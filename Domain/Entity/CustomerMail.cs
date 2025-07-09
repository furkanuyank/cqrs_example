using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cqrs_example.Entity;

public class CustomerMail
{
    public int Id { get; set; }
    public string Email { get; set; }

    public int CustomerId { get; set; }
    
    public virtual Customer Customer { get; set; }
}

public class MailConfigurator : IEntityTypeConfiguration<CustomerMail>
{
    public void Configure(EntityTypeBuilder<CustomerMail> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
        builder.HasIndex(c => c.Email).IsUnique();
    }
}