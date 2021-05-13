using CarRentApp.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentApp.Domain.EFMapping.Configs
{
     class UserConfig : IEntityTypeConfiguration<User>
     {
          public void Configure(EntityTypeBuilder<User> builder)
          {
               builder.Property(p => p.FirstName).HasMaxLength(30);
               builder.Property(p => p.LastName).HasMaxLength(30);
          }
     }
}
