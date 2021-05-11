using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentApp.Domain.EFMapping
{
     public class FuelConfig : IEntityTypeConfiguration<Fuel>
     {
          public void Configure(EntityTypeBuilder<Fuel> builder)
          {
               builder.Property(f => f.Type).HasMaxLength(20);
               builder.Property(f => f.Id).ValueGeneratedNever();
          }
     }
}
