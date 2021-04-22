using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarRentApp.API.Infrastructure.Models;
using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRentApp.API.Repositories
{
     public class EFCoreRepository : IRepository
     {
          private readonly CarRentAppDbContext _carRentAppDbContext;

          public EFCoreRepository(CarRentAppDbContext carRentAppDbContext)
          {
               _carRentAppDbContext = carRentAppDbContext;
          }

          public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : EntityBase
          {
               return await _carRentAppDbContext.Set<TEntity>().ToListAsync();
          }

          public async Task<List<TEntity>> GetAllWithInclude<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : EntityBase
          {
               var query = IncludeProperties(includeProperties);
               return await query.ToListAsync();
          }

          public async Task<TEntity> GetById<TEntity>(int id) where TEntity : EntityBase
          {
               return await _carRentAppDbContext.FindAsync<TEntity>(id);
          }

          public async Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : EntityBase
          {
               var query = IncludeProperties(includeProperties);
               return await query.FirstOrDefaultAsync(entity => entity.Id == id);
          }

          public async Task<bool> SaveAll()
          {
               return await _carRentAppDbContext.SaveChangesAsync() >= 0;
          }

          public TEntity Add<TEntity>(TEntity entity) where TEntity : EntityBase
          {
               _carRentAppDbContext.Set<TEntity>().Add(entity);
               return entity;
          }

          public TEntity Update<TEntity>(TEntity entity) where TEntity : EntityBase
          {
               _carRentAppDbContext.Entry(entity).State = EntityState.Modified;
               return entity;
          }

          public async Task<TEntity> Delete<TEntity>(int id) where TEntity : EntityBase
          {
               var entity = await _carRentAppDbContext.Set<TEntity>().FindAsync(id);
               if (entity == null)
               {
                    throw new Exception($"Object of type {typeof(TEntity)} with id { id } not found");
               }

               _carRentAppDbContext.Set<TEntity>().Remove(entity);

               return entity;
          }

          private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : EntityBase
          {
               IQueryable<TEntity> entities = _carRentAppDbContext.Set<TEntity>();
               foreach (var includeProperty in includeProperties)
               {
                    entities = entities.Include(includeProperty);
               }
               return entities;
          }

          public Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PaginatedRequest pagedRequest)
               where TEntity : EntityBase
               where TDto : class
          {
               throw new NotImplementedException();
          }
     }
}
