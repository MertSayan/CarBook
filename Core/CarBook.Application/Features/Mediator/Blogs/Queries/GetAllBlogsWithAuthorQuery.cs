using CarBook.Application.Features.Mediator.Blogs.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Blogs.Queries
{
	public class GetAllBlogsWithAuthorQuery:IRequest<List<GetAllBlogsWithAuthorQueryResult>>
	{

	}
}
