using CarRentApp.API.Dtos.Reservation;
using CarRentApp.API.Infrastructure.Exceptions;
using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.Domain;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarRentApp.API.Services
{
     public class ReservationService : IReservationService
     {
          private readonly IHttpContextAccessor _httpContextAccessor;
          private readonly IRepository _repository;

          public ReservationService(IRepository repository, IHttpContextAccessor httpContextAccessor)
          {
               _httpContextAccessor = httpContextAccessor;
               _repository = repository;
          }

          public async Task<ICollection<Reservation>> GetUsersReservations()
          {
               var client = await GetClient();

               return client.Reservations;
          }

          public async Task<Reservation> CreateClientReservation(CreateReservationDto newReservation)
          {
               var client = await GetClient();

               var reservation = new Reservation()
               {
                    ClientId = client.Id,
                    CarId = newReservation.CarId,
                    StartDate = newReservation.StartDate,
                    EndDate = newReservation.EndDate
               };

               client.Reservations.Add(reservation);

               await _repository.SaveAll();

               return reservation;
          }

          public async Task DeleteReservation(int id)
          {
               await _repository.Delete<Reservation>(id);

               await _repository.SaveAll();
          }

          public async Task<Reservation> UpdateReservation(int id, UpdateReservationDto updatedReservation)
          {
               var reservation = await _repository.GetById<Reservation>(id);

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

               _repository.Update(reservation);
               await _repository.SaveAll();

               return reservation;
          }

          public async Task<Client> GetClient()
          {
               var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

               if (userId == null)
               {
                    throw new NotFoundException("A user with such Id was not found!");
               }

               var client = await _repository.GetByIdWithInclude<Client>(int.Parse(userId), c => c.Reservations);

               if (client == null)
               {
                    throw new NotFoundException("User should be client in order to have reservations!");
               }

               return client;
          }

          public async Task<bool> IsReservationIntervalValid(Reservation reservation)
          {
               if(reservation.StartDate > reservation.EndDate)
               {
                    return false;
               }

               var carId = reservation.CarId;

               var car = await _repository.GetByIdWithInclude<Car>(carId, c => c.Reservations);

               foreach(var res in car.Reservations)
               {
                    if(res.StartDate == reservation.StartDate && res.EndDate == reservation.EndDate)
                    {
                         continue;
                    }

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
