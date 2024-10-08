using CarBook.Application.Features.Mediator.Locations.Commands;
using CarBook.Application.Features.Mediator.Locations.Queries;
using CarBook.Application.Features.Mediator.TagClouds.Commands;
using CarBook.Application.Features.Mediator.TagClouds.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloudList(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket bulutu eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommandDTO command, int id)
        {
            var value = new UpdateTagCloudCommand
            {
                TagCloudId = id,
                BlogId = command.BlogId,
                Title=command.Title,
            };
            await _mediator.Send(value);
            return Ok("Etiket bulutu güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommend(id));
            return Ok("Etiket bulutu silindi");
        }

        [HttpGet("GetTagCloudByBlogId")]
        public async Task<ActionResult> GetTagCloudByBlogId(int id)
        {
            var values=await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(values);
        }
    }
}
