
using CarBook.Application.Features.CQRS.Abouts.Commands;
using CarBook.Application.Features.CQRS.Abouts.Handlers.Read;
using CarBook.Application.Features.CQRS.Abouts.Handlers.Write;
using CarBook.Application.Features.CQRS.Abouts.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommendHandler _createAboutCommendHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;

        public AboutsController(CreateAboutCommendHandler createAboutCommendHandler, 
            UpdateAboutCommandHandler updateAboutCommandHandler,
            RemoveAboutCommandHandler removeAboutCommandHandler,
            GetAboutByIdQueryHandler getAboutByIdQueryHandler, 
            GetAboutQueryHandler getAboutQueryHandler)
        {
            _createAboutCommendHandler = createAboutCommendHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createAboutCommendHandler.Handle(command);
            return Ok("Hakkımda bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımda bilgisi silindi");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command,int id)
        {
            await _updateAboutCommandHandler.Handle(command,id);
            return Ok("Hakkımda bilgisi güncellendi");
        }
    }
}
