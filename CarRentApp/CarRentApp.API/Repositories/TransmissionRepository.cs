using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.Domain;

namespace CarRentApp.API.Repositories
{
     public class TransmissionRepository : Repository<Transmission>, ITransmissionRepository
     {
          public TransmissionRepository(CarRentAppDbContext carRentAppDbContext) : base(carRentAppDbContext)
          {
          }
     }
}
