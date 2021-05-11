using AutoMapper;
using CarRentApp.API.Dtos.Reservation;
using CarRentApp.API.Infrastructure.Exceptions;
using CarRentApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApp.API.Controllers
{
     [Authorize]
     [Route("api/[controller]")]
     [ApiController]
     public class ReservationsController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly IReservationService _reservationService;

          public ReservationsController(IMapper mapper, IReservationService reservationService)
          {
               _mapper = mapper;
               _reservationService = reservationService;
          }

          [ApiExceptionFilter]
          [HttpGet]
          public async Task<ActionResult<ICollection<ReservationDto>>> GetClientReservations()
          {
               var reservations = await _reservationService.GetUsersReservations();

               var mappedReservations = _mapper.Map<ICollection<ReservationDto>>(reservations);

               return Ok(mappedReservations);
          }

          [ApiExceptionFilter]
          [HttpPost]
          public async Task<ActionResult<ReservationDto>> PostClientReservation(CreateReservationDto newReservation)
          {
               var reservation = await _reservationService.CreateClientReservation(newReservation);

               var mappedReservation = _mapper.Map<ReservationDto>(reservation);

               return Ok(mappedReservation);
          }

          [HttpDelete]
          public async Task<IActionResult> DeleteReservationById(int id)
          {
               await _reservationService.DeleteReservation(id);

               return NoContent();
          }

          [ApiExceptionFilter]
          [HttpPatch("{id}")]
          public async Task<IActionResult> UpdateReservation(int id, [FromBody] UpdateReservationDto updatedReservation)
          {
               var reservation = await _reservationService.UpdateReservation(id, updatedReservation);

               var mappedReservation = _mapper.Map<ReservationDto>(reservation);

               return Ok(mappedReservation);
          }
     }
}
