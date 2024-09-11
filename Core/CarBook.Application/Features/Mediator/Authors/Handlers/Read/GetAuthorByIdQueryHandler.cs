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
    public class GetAuthorByIdQueryHandler : BaseHandler<Author>, IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        public GetAuthorByIdQueryHandler(IRepository<Author> repository) : base(repository)
        {
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                AuthorId = value.AuthorId,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Name = value.Name
            };
        }
    }
}
