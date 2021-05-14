using CarRentApp.Domain.EFMapping.Repositories.Interfaces;
using CarRentApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentApp.Domain.EFMapping.Repositories
{
     public class CarRepository : Repository<Car>, ICarRepository
     {
          private readonly DbSet<Car> _cars;
          public CarRepository(CarRentAppDbContext carRentAppDbContext) : base(carRentAppDbContext)
          {
               _cars = carRentAppDbContext.Set<Car>();
          }

          public async Task<List<Car>> GetCarsWithInclude(params Expression<Func<Car, object>>[] includeProperties)
          {
               IQueryable<Car> carsWithInlude = _cars;

               foreach (var includeProperty in includeProperties)
               {
                    carsWithInlude = carsWithInlude.Include(includeProperty);
               }

               return await carsWithInlude.ToListAsync();
          }

          public async Task<ICollection<Car>> GetFilteredCarBodyCars(CarBodyEnum? carBodyId, params Expression<Func<Car, object>>[] includeProperties)
          {
               IQueryable<Car> carsWithInlude = carBodyId == null ? _cars : _cars.Where(c => c.CarBodyId == carBodyId);

               foreach (var includeProperty in includeProperties)
               {
                    carsWithInlude = carsWithInlude.Include(includeProperty);
               }

               return await carsWithInlude.ToListAsync();
          }
     }
}
