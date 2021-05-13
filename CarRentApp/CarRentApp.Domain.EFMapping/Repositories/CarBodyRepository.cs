

using CarRentApp.Domain.EFMapping.Repositories.Interfaces;

namespace CarRentApp.Domain.EFMapping.Repositories
{
     public class CarBodyRepository : Repository<CarBody>, ICarBodyRepository
     {
          public CarBodyRepository(CarRentAppDbContext carRentAppDbContext) : base(carRentAppDbContext)
          {
          }
     }
}
