using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarRentApp.API.Infrastructure.Models;
using CarRentApp.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentApp.API.Infrastructure.Extensions
{
     public static class QueryableExtensions
     {
          public async static Task<PaginatedResult<TDto>> CreatePaginatedResultAsync<TEntity, TDto>(this IQueryable<TEntity> query, PaginatedRequest paginatedRequest, IMapper mapper)
            where TEntity : IEntity
            where TDto : class
          {
               query = query.ApplyFilters(paginatedRequest);

               var total = await query.CountAsync();

               query = query.Paginate(paginatedRequest);

               var projectionResult = query.ProjectTo<TDto>(mapper.ConfigurationProvider);

               projectionResult = projectionResult.Sort(paginatedRequest);

               var listResult = await projectionResult.ToListAsync();

               return new PaginatedResult<TDto>()
               {
                    Items = listResult,
                    PageSize = paginatedRequest.PageSize,
                    PageIndex = paginatedRequest.PageIndex,
                    Total = total
               };
          }

          private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginatedRequest paginatedRequest)
          {
               var entities = query.Skip((paginatedRequest.PageIndex) * paginatedRequest.PageSize).Take(paginatedRequest.PageSize);
               return entities;
          }

          private static IQueryable<T> Sort<T>(this IQueryable<T> query, PaginatedRequest paginatedRequest)
          {
               if (!string.IsNullOrWhiteSpace(paginatedRequest.ColumnNameForSorting))
               {
                   // query = query.OrderBy(paginatedRequest.ColumnNameForSorting + " " + paginatedRequest.SortDirection);
               }
               return query;
          }

          private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, PaginatedRequest paginatedRequest)
          {
               var predicate = new StringBuilder();
               var requestFilters = paginatedRequest.RequestFilters;
               for (int i = 0; i < requestFilters.Filters.Count; i++)
               {
                    if (i > 0)
                    {
                         predicate.Append($" {requestFilters.LogicalOperator} ");
                    }
                    predicate.Append(requestFilters.Filters[i].Path + $".{nameof(string.Contains)}(@{i})");
               }

               if (requestFilters.Filters.Any())
               {
                    var propertyValues = requestFilters.Filters.Select(filter => filter.Value).ToArray();

                   // query = query.Where(predicate.ToString(), propertyValues);
               }

               return query;
          }
     }
}
