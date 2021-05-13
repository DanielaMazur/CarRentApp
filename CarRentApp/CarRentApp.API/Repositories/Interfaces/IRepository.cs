using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentApp.Domain;

namespace CarRentApp.API.Repositories.Interfaces
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
