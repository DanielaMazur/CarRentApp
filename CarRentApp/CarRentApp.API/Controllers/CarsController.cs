using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarRentApp.API.Dtos.Car;
using CarRentApp.API.Infrastructure.Exceptions;
using CarRentApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApp.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class CarsController : ControllerBase
     {
          private readonly IMapper _mapper;
          private readonly ICarService _carService;

          public CarsController(IMapper mapper, ICarService carService)
          {
               _mapper = mapper;
               _carService = carService;
          }

          [HttpGet]
          public async Task<IActionResult> Get()
          {
               var cars = await _carService.GetCars();

               var carsDto = _mapper.Map<List<CarDto>>(cars);

               return Ok(carsDto);
          }

          [HttpGet("{id}")]
          [ApiExceptionFilter]
          public async Task<IActionResult> Get(int id)
          {
               var car = await _carService.GetCarById(id);

               var carDto = _mapper.Map<CarDto>(car);

               return Ok(carDto);
          }

          [HttpPost]
          [ApiExceptionFilter]
          public async Task<IActionResult> Post(CreateCarDto newCar)
          {
               var createdCar = await _carService.AddNewCar(newCar);

               var carDto = _mapper.Map<CarDto>(createdCar);
               
               return Ok(carDto);
          }

          [HttpPatch("{id}")]
          [ApiExceptionFilter]
          public async Task<IActionResult> Patch(int id, [FromBody] UpdateCarDto updatedCar)
          {
               var car = await _carService.UpdateCar(id, updatedCar);

               var carDto = _mapper.Map<CarDto>(car);

               return Ok(carDto);
          }

          [HttpDelete]
          public async Task<IActionResult> Delete(int id)
          {
               await _carService.RemoveCarById(id);

               return NoContent();
          }
     }
}
