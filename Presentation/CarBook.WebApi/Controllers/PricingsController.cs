using CarBook.Application.Features.Mediator.Pricings.Commands;
using CarBook.Application.Features.Mediator.Pricings.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingList(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ödeme türü eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommandDTO command, int id)
        {
            var value = new UpdatePricingCommand
            {
                PricingId = id,
                Name = command.Name,
            };
            await _mediator.Send(value);
            return Ok("Ödeme türü güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Ödeme türü silindi");
        }
    }
}
