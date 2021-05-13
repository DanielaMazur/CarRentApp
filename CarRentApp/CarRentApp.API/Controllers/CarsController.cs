using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarRentApp.API.Models.Car;
using CarRentApp.API.Infrastructure.Exceptions;
using CarRentApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

          [AllowAnonymous]
          [HttpGet]
          public async Task<IActionResult> Get()
          {
               var cars = await _carService.GetCars();

               var carsDto = _mapper.Map<List<CarModel>>(cars);

               return Ok(carsDto);
          }

          [AllowAnonymous]
          [HttpGet("{id}")]
          [ApiExceptionFilter]
          public async Task<IActionResult> Get(int id)
          {
               var car = await _carService.GetCarById(id);

               var carDto = _mapper.Map<CarModel>(car);

               return Ok(carDto);
          }

          [HttpPost]
          [ApiExceptionFilter]
          public async Task<IActionResult> Post(CreateCarModel newCar)
          {
               var createdCar = await _carService.AddNewCar(newCar);

               var carDto = _mapper.Map<CarModel>(createdCar);
               
               return Ok(carDto);
          }


          [HttpPatch("{id}")]
          [ApiExceptionFilter]
          public async Task<IActionResult> Patch(int id, [FromBody] UpdateCarModel updatedCar)
          {
               var car = await _carService.UpdateCar(id, updatedCar);

               var carDto = _mapper.Map<CarModel>(car);

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
