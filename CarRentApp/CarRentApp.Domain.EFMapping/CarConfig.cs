using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentApp.Domain.EFMapping
{
     public class CarConfig : IEntityTypeConfiguration<Car>
     {
          public void Configure(EntityTypeBuilder<Car> builder)
          {
               builder.Property(c => c.Brand).HasMaxLength(30).IsRequired();
               builder.Property(c => c.Color).HasMaxLength(20).IsRequired();
               builder.Property(c => c.FabricationYear).IsRequired();
               builder.Property(c => c.Model).HasMaxLength(100).IsRequired();

               builder.Property(c => c.RegistrationNumber).HasMaxLength(10).IsRequired();
               builder.HasIndex(c => c.RegistrationNumber).IsUnique();
          }
     }
}
