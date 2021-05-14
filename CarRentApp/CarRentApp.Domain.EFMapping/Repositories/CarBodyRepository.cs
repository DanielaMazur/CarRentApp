

using CarRentApp.Domain.EFMapping.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentApp.Domain.EFMapping.Repositories
{
     public class CarBodyRepository : Repository<CarBody>, ICarBodyRepository
     {
          private DbSet<CarBody> _carBodySet;

          public CarBodyRepository(CarRentAppDbContext carRentAppDbContext) : base(carRentAppDbContext)
          {
               _carBodySet= carRentAppDbContext.Set<CarBody>();
          }

          public async Task<ICollection<CarBody>> GetFirstXCarBodies(int? numberOfCarBodies)
          {
               var oderedByPriorityCarBodies = _carBodySet.OrderBy(c => c.Priority);

               if(!numberOfCarBodies.HasValue || numberOfCarBodies == 0)
               {
                    return await oderedByPriorityCarBodies.ToListAsync();
               }

               return await _carBodySet.OrderBy(c => c.Priority).Take(numberOfCarBodies.Value).ToListAsync();
          }
     }
}
