using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Blogs.Queries;
using CarBook.Application.Features.Mediator.Blogs.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Blogs.Handlers.Read
{
    public class GetBlogByIdQueryHandler : BaseHandler<Blog>, IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        public GetBlogByIdQueryHandler(IRepository<Blog> repository) : base(repository)
        {
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                AuthorId=value.AuthorId,
                BlogId=value.BlogId,
                CategoryId=value.CategoryId,
                CoverImageUrl=value.CoverImageUrl,
                Title = value.Title
            };
        }
    }
}
