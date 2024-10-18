
using CarBook.Application.Features.CQRS.Banners.Queries;
using CarBook.Application.Features.CQRS.Cars.Commands;
using CarBook.Application.Features.CQRS.Cars.Handlers.Read;
using CarBook.Application.Features.CQRS.Cars.Handlers.Write;
using CarBook.Application.Features.Mediator.Statistics.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommendHandler _removeCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandQueryHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler,
            UpdateCarCommandHandler updateCarCommandHandler,
            RemoveCarCommendHandler removeCarCommandHandler,
            GetCarByIdQueryHandler getCarByIdQueryHandler,
            GetCarQueryHandler getCarQueryHandler,
            GetCarWithBrandQueryHandler getCarWithBrandQueryHandler,
            GetLast5CarsWithBrandQueryHandler getLast5CarsWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLast5CarsWithBrandQueryHandler = getLast5CarsWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Car basariyla oluşturuldu");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Car basariyla silindi");
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car basariyla güncellendi");
        }
        [HttpGet("brand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var values=await _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetLast5CarsWithBrandQueryHandler")]
        public async Task<IActionResult> GetLast5CarsWithBrandQueryHandler()
        {
            var values = await _getLast5CarsWithBrandQueryHandler.Handle();
            return Ok(values);
        }

        




    }
}
