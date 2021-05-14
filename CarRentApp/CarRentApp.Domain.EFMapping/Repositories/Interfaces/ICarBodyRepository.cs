using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApp.Domain.EFMapping.Repositories.Interfaces
{
     public interface ICarBodyRepository : IRepository<CarBody>
     {
          Task<ICollection<CarBody>> GetFirstXCarBodies(int? numberOfCarBodies);
     }
}
