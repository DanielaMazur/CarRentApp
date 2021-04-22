using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentApp.Domain.EFMapping
{
     public class PhotoConfig : IEntityTypeConfiguration<Photo>
     {
          public void Configure(EntityTypeBuilder<Photo> builder)
          {
               builder.Property(p => p.Path).HasMaxLength(2000).IsRequired();
          }
     }
}
