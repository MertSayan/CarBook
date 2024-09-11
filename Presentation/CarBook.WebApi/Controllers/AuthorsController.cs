﻿using CarBook.Application.Features.Mediator.Authors.Commands;
using CarBook.Application.Features.Mediator.Authors.Queries;
using CarBook.Application.Features.Mediator.Testimonials.Commands;
using CarBook.Application.Features.Mediator.Testimonials.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var values = await _mediator.Send(new GetAuthorQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorList(int id)
        {
            var value = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Author eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommandDTO command, int id)
        {
            var value = new UpdateAuthorCommand
            {
                Name = command.Name,
                ImageUrl = command.ImageUrl,
                AuthorId = id,
                Description=command.Description,
            };
            await _mediator.Send(value);
            return Ok("Author güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok("SocialMedia silindi");
        }

    }
}
