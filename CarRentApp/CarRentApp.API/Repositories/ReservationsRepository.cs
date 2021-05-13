using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentApp.API.Repositories
{
     public class ReservationsRepository : Repository<Reservation>, IReservationRepository
     {
          private readonly DbSet<Reservation> _reservations;

          public ReservationsRepository(CarRentAppDbContext carRentAppDbContext) : base(carRentAppDbContext)
          {
               _reservations = carRentAppDbContext.Set<Reservation>();
          }
          public async Task<List<Reservation>> GetClientReservations(int userId)
          {
               var clientReservations = await _reservations.Include(r => r.Car)
                                             .Include(r => r.Car.Photos)
                                             .Where(r => r.UserId == userId)
                                             .ToListAsync();

               return clientReservations;
          }

          public async Task<List<Reservation>> ReservationsWithIncludes(params Expression<Func<Reservation, object>>[] includeProperties)
          {
               IQueryable<Reservation> carsWithInlude = _reservations;

               foreach (var includeProperty in includeProperties)
               {
                    carsWithInlude = carsWithInlude.Include(includeProperty);
               }

               return await carsWithInlude.ToListAsync();
          }

          public async Task<List<Reservation>> GetCarReservations(int carId)
          {
               var carReservations = _reservations.Where(r => r.CarId == carId);

               return await carReservations.ToListAsync();
          }
     }
}
