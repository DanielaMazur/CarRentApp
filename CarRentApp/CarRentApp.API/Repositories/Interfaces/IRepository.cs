using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarRentApp.API.Infrastructure.Models;
using CarRentApp.Domain.Intefaces;

namespace CarRentApp.API.Repositories.Interfaces
{
     public interface IRepository
     {
          Task<List<TEntity>> GetAll<TEntity>() where TEntity : class, IEntity;
          Task<TEntity> GetById<TEntity>(int id) where TEntity : class, IEntity;
          Task<List<TEntity>> GetAllWithInclude<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) 
               where TEntity : class, IEntity;
          Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) 
               where TEntity : class, IEntity;
          Task<bool> SaveAll();
          TEntity Add<TEntity>(TEntity entity) where TEntity : class, IEntity;
          TEntity Update<TEntity>(TEntity entity) where TEntity : IEntity;
          Task<TEntity> Delete<TEntity>(int id) where TEntity : class, IEntity;
          Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PaginatedRequest pagedRequest)
               where TEntity : IEntity where TDto : class;
     }
}
