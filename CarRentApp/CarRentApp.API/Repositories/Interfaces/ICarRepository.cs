using CarRentApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentApp.API.Repositories.Interfaces
{
     public interface ICarRepository : IRepository<Car>
     {
          Task<List<Car>> GetCarsWithInclude(params Expression<Func<Car, object>>[] includeProperties);
     }
}
