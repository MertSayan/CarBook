using CarBook.Application.Features.Mediator.SocialMedias.Commands;
using CarBook.Application.Features.Mediator.SocialMedias.Queries;
using CarBook.Application.Features.Mediator.Testimonials.Commands;
using CarBook.Application.Features.Mediator.Testimonials.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialList(int id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Testimonial eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommandDTO command, int id)
        {
            var value = new UpdateTestimonialCommand
            {
                TestimonialId = id,
                ImageUrl = command.ImageUrl,
                Name = command.Name,
                Comment = command.Comment,
                Title = command.Title
            };
            await _mediator.Send(value);
            return Ok("Testimonial güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("SocialMedia silindi");
        }
    }
}
