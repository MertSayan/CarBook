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
    public class GetBlogQueryHandler : BaseHandler<Blog>, IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        public GetBlogQueryHandler(IRepository<Blog> repository) : base(repository)
        {
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetBlogQueryResult
            {
                AuthorId = x.AuthorId,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                Title=x.Title,
            }).ToList();
        }
    }
}
