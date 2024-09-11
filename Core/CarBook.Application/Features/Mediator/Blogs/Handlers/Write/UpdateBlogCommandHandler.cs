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
    public class UpdateBlogCommandHandler : BaseHandler<Blog>, IRequestHandler<UpdateBlogCommand>
    {
        public UpdateBlogCommandHandler(IRepository<Blog> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.BlogId);
            value.Title = request.Title;
            value.AuthorId = request.AuthorId;
            value.CategoryId = request.CategoryId;
            value.CoverImageUrl = request.CoverImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
