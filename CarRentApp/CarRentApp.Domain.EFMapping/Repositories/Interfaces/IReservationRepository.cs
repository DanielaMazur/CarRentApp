using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentApp.Domain.EFMapping.Repositories.Interfaces
{
     public interface IReservationRepository : IRepository<Reservation>
     {
          Task<List<Reservation>> GetClientReservations(int clientId);
          Task<List<Reservation>> ReservationsWithIncludes(params Expression<Func<Reservation, object>>[] includeProperties);
          Task<List<Reservation>> GetCarReservations(int carId);
     }
}
