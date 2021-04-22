using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarRentApp.API.Infrastructure.Models;
using CarRentApp.Domain;

namespace CarRentApp.API.Repositories.Interfaces
{
     public interface IRepository
     {
          Task<TEntity> GetById<TEntity>(int id) where TEntity : EntityBase;
          Task<List<TEntity>> GetAllWithInclude<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : EntityBase;
          Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : EntityBase;
          Task<List<TEntity>> GetAll<TEntity>() where TEntity : EntityBase;
          Task<bool> SaveAll();
          TEntity Add<TEntity>(TEntity entity) where TEntity : EntityBase;
          TEntity Update<TEntity>(TEntity entity) where TEntity : EntityBase;
          Task<TEntity> Delete<TEntity>(int id) where TEntity : EntityBase;
          Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PaginatedRequest pagedRequest) where TEntity : EntityBase where TDto : class;
     }
}
