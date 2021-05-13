using CarRentApp.Domain.EFMapping.Repositories.Interfaces;

namespace CarRentApp.Domain.EFMapping.Repositories
{
     public class TransmissionRepository : Repository<Transmission>, ITransmissionRepository
     {
          public TransmissionRepository(CarRentAppDbContext carRentAppDbContext) : base(carRentAppDbContext)
          {
          }
     }
}
