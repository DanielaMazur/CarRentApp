using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentApp.API.Infrastructure.Exceptions;
using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRentApp.API.Repositories
{
     public class Repository<T> : IRepository<T> where T : EntityBase
     {
          private readonly CarRentAppDbContext _carRentAppDbContext;
          private readonly DbSet<T> _dbSet;

          public Repository(CarRentAppDbContext carRentAppDbContext)
          {
               _carRentAppDbContext = carRentAppDbContext;
               _dbSet = carRentAppDbContext.Set<T>();
          }

          public async Task<List<T>> GetAll()
          {
               return await _dbSet.ToListAsync();
          }
          public async Task<T> GetById(int id)
          {
               return await _carRentAppDbContext.FindAsync<T>(id);
          }
          public async Task<bool> SaveAll()
          {
               return await _carRentAppDbContext.SaveChangesAsync() >= 0;
          }

          public T Add(T entity)
          {
               _dbSet.Add(entity);

               return entity;
          }

          public T Update(T entity)
          {
               _carRentAppDbContext.Entry(entity).State = EntityState.Modified;

               return entity;
          }

          public async Task<T> Delete(int id)
          {
               var entity = await _dbSet.FindAsync(id);
             
               if (entity == null)
               {
                    throw new NotFoundException($"Object of type {typeof(T)} with id { id } not found");
               }

              _dbSet.Remove(entity);

               return entity;
          }
     }
}
