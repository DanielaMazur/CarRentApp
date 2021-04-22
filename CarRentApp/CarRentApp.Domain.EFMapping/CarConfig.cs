using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarRentApp.Domain.Enums;

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
               

               builder.Property(c => c.Body).HasConversion(b => b.ToString(), b => Enum.Parse<CarBody>(b)).HasMaxLength(20);
               builder.Property(c => c.Fuel).HasConversion(f => f.ToString(), f => Enum.Parse<Fuel>(f)).HasMaxLength(20);
               builder.Property(c => c.Transmission).HasConversion(t => t.ToString(), t => Enum.Parse<Transmission>(t)).HasMaxLength(20);

               builder.Property(c => c.RegistrationNumber).HasMaxLength(10).IsRequired();
               builder.HasIndex(c => c.RegistrationNumber).IsUnique();
          }
     }
}
