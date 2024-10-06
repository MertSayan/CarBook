using CarBook.Application.Features.Mediator.Blogs.Queries;
using CarBook.Application.Features.Mediator.Blogs.Results;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Blogs.Handlers.Read
{
	public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
	{
		private readonly IBlogRepository _repository;

		public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllBlogsWithAuthors();
			return values.Select(x => new GetAllBlogsWithAuthorQueryResult
			{
				AuthorId = x.AuthorId,
				AuthorName=x.Author.Name,
				BlogId=x.BlogId,
				CategoryId=x.CategoryId,
				Title=x.Title,
				CoverImageUrl=x.CoverImageUrl,
				CreatedDate=x.CreatedDate,
				Description=x.Description
			}).ToList();
		}
	}
}
