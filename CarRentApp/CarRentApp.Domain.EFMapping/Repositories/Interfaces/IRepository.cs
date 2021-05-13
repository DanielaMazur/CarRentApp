using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApp.Domain.EFMapping.Repositories.Interfaces
{
     public interface IRepository<T> where T : EntityBase
     {
          Task<List<T>> GetAll();
          Task<T> GetById(int id);
          T Add(T entity);
          T Update(T entity);
          Task<T> Delete(int id); 
          Task<bool> SaveAll();
     }
}
