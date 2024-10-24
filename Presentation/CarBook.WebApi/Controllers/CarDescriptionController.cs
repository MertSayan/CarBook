using CarBook.Application.Features.Mediator.CarDescriptions.Queries;
using CarBook.Application.Features.Mediator.CarFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarDescriptionController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> CarDescriptionByCarId(int id)
		{
			var value =  _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
			return Ok(value);
		}
	}
}
