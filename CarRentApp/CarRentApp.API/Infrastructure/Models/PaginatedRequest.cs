﻿namespace CarRentApp.API.Infrastructure.Models
{
     public class PaginatedRequest
     {
          public PaginatedRequest()
          {
               RequestFilters = new RequestFilters();
          }

          public int PageIndex { get; set; }

          public int PageSize { get; set; }

          public string ColumnNameForSorting { get; set; }

          public string SortDirection { get; set; }

          public RequestFilters RequestFilters { get; set; }
     }
}
