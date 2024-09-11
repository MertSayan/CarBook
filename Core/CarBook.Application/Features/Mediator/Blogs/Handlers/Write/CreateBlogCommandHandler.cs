using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Blogs.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Blogs.Handlers.Write
{
    public class CreateBlogCommandHandler : BaseHandler<Blog>, IRequestHandler<CreateBlogCommand>
    {
        public CreateBlogCommandHandler(IRepository<Blog> repository) : base(repository)
        {
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog
            {
                Title = request.Title,
                CoverImageUrl = request.CoverImageUrl,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                
            });
        }
    }
}
