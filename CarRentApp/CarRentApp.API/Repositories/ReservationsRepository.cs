using CarRentApp.API.Repositories.Interfaces;
using CarRentApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentApp.API.Repositories
{
     public class ReservationsRepository : EFCoreRepository, IReservationRepository
     {
          private readonly CarRentAppDbContext _carRentAppDbContext;
          public ReservationsRepository(CarRentAppDbContext carRentAppDbContext) : base(carRentAppDbContext)
          {
               _carRentAppDbContext = carRentAppDbContext;
          }
          public async Task<List<Reservation>> GetClientReservations(int clientId)
          {
               var client = await GetById<Client>(clientId);

               var reservations = await _carRentAppDbContext.Set<Reservation>().Include(r => r.Car).Include(r => r.Car.Photos).ToListAsync();

               var clietReservations = reservations.Where(r => r.ClientId == client.Id).ToList();

               return clietReservations;
          }

     }
}
