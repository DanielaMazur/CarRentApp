using CarRentApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentApp.Domain.EFMapping.Repositories.Interfaces
{
     public interface ICarRepository : IRepository<Car>
     {
          Task<List<Car>> GetCarsWithInclude(params Expression<Func<Car, object>>[] includeProperties);
          Task<ICollection<Car>> GetFilteredCarBodyCars(CarBodyEnum? carBodyId, params Expression<Func<Car, object>>[] includeProperties);
     }
}
