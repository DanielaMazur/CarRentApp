using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.Domain;

namespace CarRentApp.API.Repositories
{
     public class CarBodyRepository : Repository<CarBody>, ICarBodyRepository
     {
          public CarBodyRepository(CarRentAppDbContext carRentAppDbContext) : base(carRentAppDbContext)
          {
          }
     }
}
