using CarRentApp.API.Models.Reservation;
using CarRentApp.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApp.API.Services.Interfaces
{
     public interface IReservationService
     {
          Task<ICollection<Reservation>> GetUsersReservations();
          Task<Reservation> CreateClientReservation(CreateReservationModel newReservation);
          Task DeleteReservation(int id);
          Task<Reservation> UpdateReservation(int id, UpdateReservationModel updatedReservation);
          Task<ICollection<DateTime[]>> GetCarReservedDayRanges(int carId);
     }
}
