using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentApp.Domain.EFMapping
{
     public class ClientConfig : IEntityTypeConfiguration<Client>
     {
          public void Configure(EntityTypeBuilder<Client> builder)
          {
               builder.Property(c => c.DriverLicenseId).HasMaxLength(20).IsRequired();
               builder.HasIndex(c => c.DriverLicenseId).IsUnique();
          }
     }
}
