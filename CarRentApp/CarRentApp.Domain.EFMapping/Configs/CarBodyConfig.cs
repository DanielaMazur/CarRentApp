using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentApp.Domain.EFMapping.Configs
{
     public class CarBodyConfig : IEntityTypeConfiguration<CarBody>
     {
          public void Configure(EntityTypeBuilder<CarBody> builder)
          {
               builder.Property(c => c.Type).HasMaxLength(20);
               builder.Property(s => s.Id).ValueGeneratedNever();
          }
     }
}
