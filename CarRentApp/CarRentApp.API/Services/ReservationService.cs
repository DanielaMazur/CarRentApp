using CarRentApp.API.Models.Reservation;
using CarRentApp.API.Infrastructure.Exceptions;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.Domain;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CarRentApp.Domain.EFMapping.Repositories.Interfaces;
using System.Linq;
using System;

namespace CarRentApp.API.Services
{
     public class ReservationService : IReservationService
     {
          private readonly IHttpContextAccessor _httpContextAccessor;
          private readonly IReservationRepository _reservationRepository;

          public ReservationService(IHttpContextAccessor httpContextAccessor, IReservationRepository reservationRepository)
          {
               _httpContextAccessor = httpContextAccessor;
               _reservationRepository = reservationRepository;
          }

          public async Task<ICollection<Reservation>> GetUsersReservations()
          {
               var clientId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

               var reservations = await _reservationRepository.GetClientReservations(int.Parse(clientId));

               return reservations;
          }

          public async Task<Reservation> CreateClientReservation(CreateReservationModel newReservation)
          {
               var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

               var reservation = new Reservation()
               {
                    UserId = int.Parse(userId),
                    CarId = newReservation.CarId,
                    StartDate = newReservation.StartDate,
                    EndDate = newReservation.EndDate
               };

               if (!await IsReservationIntervalValid(reservation))
               {
                    throw new InvalidInputException("Date interval is not valid!");
               }

               _reservationRepository.Add(reservation);
               await _reservationRepository.SaveAll();

               return reservation;
          }

          public async Task DeleteReservation(int id)
          {
               await _reservationRepository.Delete(id);

               await _reservationRepository.SaveAll();
          }

          public async Task<Reservation> UpdateReservation(int id, UpdateReservationModel updatedReservation)
          {
               var reservation = await _reservationRepository.GetById(id);

               if (reservation == null)
               {
                    throw new NotFoundException("A reservation with such Id was not found!");
               }

               if (updatedReservation.StartDate.HasValue)
               {
                    reservation.StartDate = updatedReservation.StartDate.Value;
               }

               if (updatedReservation.EndDate.HasValue)
               {
                    reservation.EndDate = updatedReservation.EndDate.Value;
               }

               if (!await IsReservationIntervalValid(reservation))
               {
                    throw new InvalidInputException("Date interval is not valid!");
               }

               _reservationRepository.Update(reservation);
               await _reservationRepository.SaveAll();

               return reservation;
          }

          public async Task<ICollection<DateTime[]>> GetCarReservedDayRanges(int carId)
          {
               var carReservations = await _reservationRepository.GetCarReservations(carId);

               var reservedDayRanges = carReservations.Select(r => new DateTime[2] { r.StartDate, r.EndDate });

               return reservedDayRanges.ToList();
          }

          private async Task<bool> IsReservationIntervalValid(Reservation reservation)
          {
               if(reservation.StartDate > reservation.EndDate)
               {
                    return false;
               }

               var carId = reservation.CarId;

               var carsReservations = await _reservationRepository.GetCarReservations(carId);

               foreach(var res in carsReservations)
               {
                    if(res.StartDate <= reservation.StartDate && res.EndDate >= reservation.StartDate)
                    {
                         return false;
                    }

                    if(res.StartDate <= reservation.EndDate && res.EndDate >= reservation.EndDate)
                    {
                         return false;
                    }
               }

               return true;
          }
     }
}
