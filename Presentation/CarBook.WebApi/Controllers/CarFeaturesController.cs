using CarBook.Application.Features.Mediator.CarFeatures.Commands;
using CarBook.Application.Features.Mediator.CarFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarIdQuery(int id)
        {
            var value = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(value);
        }
        [HttpGet("CarFeatureChangeAvailableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChanteToFalseCommand(id));
            return Ok("Güncelleme oldu");
        }
        [HttpGet("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChanteToTrueCommand(id));
            return Ok("Güncelleme oldu");
        }
    }
}
