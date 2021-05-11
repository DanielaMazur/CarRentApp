using CarRentApp.API.Dtos.Reservation;
using CarRentApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApp.API.Services.Interfaces
{
     public interface IReservationService
     {
          Task<ICollection<Reservation>> GetUsersReservations();
          Task<Reservation> CreateClientReservation(CreateReservationDto newReservation);
          Task DeleteReservation(int id);
          Task<Reservation> UpdateReservation(int id, UpdateReservationDto updatedReservation);
     }
}
