using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentApp.API.Infrastructure.Annotations
{
     public class YearRange : RangeAttribute
     {
          public YearRange(int startYear, int endYear)
          : base(typeof(DateTime), new DateTime(startYear, 1, 1).ToShortDateString(), new DateTime(endYear, 1, 1).ToShortDateString()) { }

          public YearRange(int startYear)
          : base(typeof(DateTime), new DateTime(startYear, 1, 1).ToShortDateString(), new DateTime(DateTime.Now.Year, 1, 1).ToShortDateString()) { }

     }
}
