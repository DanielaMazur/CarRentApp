using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentApp.Domain.EFMapping
{
     public class TransmissionConfig : IEntityTypeConfiguration<Transmission>
     {
          public void Configure(EntityTypeBuilder<Transmission> builder)
          {
               builder.Property(t => t.Type).HasMaxLength(20);
               builder.Property(t => t.Id).ValueGeneratedNever();
          }
     }
}
