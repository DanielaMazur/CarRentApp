using CarRentApp.Domain.EFMapping.Repositories.Interfaces;

namespace CarRentApp.Domain.EFMapping.Repositories
{
     public class FuelRepository : Repository<Fuel>, IFuelRepository
     {
          public FuelRepository(CarRentAppDbContext carRentAppDbContext) : base(carRentAppDbContext)
          {
          }
     }
}
