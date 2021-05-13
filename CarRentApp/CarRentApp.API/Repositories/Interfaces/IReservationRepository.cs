using CarRentApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApp.API.Repositories.Interfaces
{
     public interface IReservationRepository
     {
          Task<List<Reservation>> GetClientReservations(int clientId);
     }
}
