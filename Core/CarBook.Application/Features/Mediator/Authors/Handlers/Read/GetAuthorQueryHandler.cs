using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Authors.Queries;
using CarBook.Application.Features.Mediator.Authors.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Authors.Handlers.Read
{
    public class GetAuthorQueryHandler : BaseHandler<Author>, IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        public GetAuthorQueryHandler(IRepository<Author> repository) : base(repository)
        {
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name= x.Name,
            }).ToList();    
        }
    }
}
