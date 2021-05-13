using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentApp.Domain.EFMapping.Configs
{
     public class ReservationConfig : IEntityTypeConfiguration<Reservation>
     {
          public void Configure(EntityTypeBuilder<Reservation> builder)
          {
               builder.Property(r => r.StartDate).IsRequired();
               builder.Property(r => r.EndDate).IsRequired();
          }
     }
}
