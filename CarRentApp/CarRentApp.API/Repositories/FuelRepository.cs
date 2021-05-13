using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.Domain;

namespace CarRentApp.API.Repositories
{
     public class FuelRepository : Repository<Fuel>, IFuelRepository
     {
          public FuelRepository(CarRentAppDbContext carRentAppDbContext) : base(carRentAppDbContext)
          {
          }
     }
}
