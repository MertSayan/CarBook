using CarBook.Application.Features.Mediator.Blogs.Commands;
using CarBook.Application.Features.Mediator.Blogs.Handlers.Read;
using CarBook.Application.Features.Mediator.Blogs.Queries;
using CarBook.Application.Features.Mediator.Testimonials.Commands;
using CarBook.Application.Features.Mediator.Testimonials.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogList(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommandDTO command, int id)
        {
            var value = new UpdateBlogCommand
            {
                CoverImageUrl = command.CoverImageUrl,
                AuthorId = command.AuthorId,
                BlogId = id,
                CategoryId = command.CategoryId,
                Title = command.Title
            };
            await _mediator.Send(value);
            return Ok("Blog güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("SocialMedia silindi");
        }

        [HttpGet("GetLast3BlogsWithAuthorsList")]
        public async Task<IActionResult> GetLast3BlogsWithAuthorsList()
        {
            var values=await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
            return Ok(values);
        }

		[HttpGet("GetAllBlogsWithAuthorList")]
		public async Task<IActionResult> GetAllBlogsWithAuthorList()
		{
			var values = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
			return Ok(values);
		}

        [HttpGet("GetBlogByAuthorId")]
        public async Task<IActionResult> GetBlogByAuthorId(int id)
        {
            var values = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
            return Ok(values);
        }
    }
}
