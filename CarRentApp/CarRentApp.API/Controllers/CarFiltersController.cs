using AutoMapper;
using CarRentApp.API.Dtos.CarFilters;
using CarRentApp.API.Services.Interfaces;
using CarRentApp.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentApp.API.Controllers
{
     [AllowAnonymous]
     [Route("api/filters")]
     [ApiController]
     public class CarFiltersController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly ICarFiltersService _carFiltersService;

          public CarFiltersController(IMapper mapper, ICarFiltersService carFiltersService)
          {
               _mapper = mapper;
               _carFiltersService = carFiltersService;
          }

          [HttpGet]
          public async Task<IActionResult> GetFilters()
          {
               var transmissions = await _carFiltersService.GetTransmissions();
               var fuel = await _carFiltersService.GetFuel();
               var carBody = await _carFiltersService.GetCarBody();

               var filtersDto = _mapper.Map<CarFiltersDto>(new CarFilters(){ Transmission = transmissions, Fuel = fuel, CarBody = carBody });

               return Ok(filtersDto);
          }

          [HttpGet("transmission")]
          public async Task<IActionResult> GetTransmisson()
          {
               var transmissions = await _carFiltersService.GetTransmissions();

               var transmissionsDto = _mapper.Map<ICollection<TransmissionDto>>(transmissions);

               return Ok(transmissionsDto);
          }

          [HttpGet("fuel")]
          public async Task<IActionResult> GetFuel()
          {
               var fuel = await _carFiltersService.GetFuel();

               var fuelDto = _mapper.Map<ICollection<FuelDto>>(fuel);

               return Ok(fuelDto);
          }

          [HttpGet("car-body")]
          public async Task<IActionResult> GetCarBody()
          {
               var carBody = await _carFiltersService.GetCarBody();

               var carBodyDto = _mapper.Map<ICollection<CarBodyDto>>(carBody);

               return Ok(carBodyDto);
          }
     }
}
