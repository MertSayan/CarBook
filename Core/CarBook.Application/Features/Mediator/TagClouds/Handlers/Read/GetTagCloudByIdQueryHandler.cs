using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.TagClouds.Queries;
using CarBook.Application.Features.Mediator.TagClouds.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.TagClouds.Handlers.Read
{
    public class GetTagCloudByIdQueryHandler : BaseHandler<TagCloud>, IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository) : base(repository)
        {
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var values= await _repository.GetByIdAsync(request.Id);
            return new GetTagCloudByIdQueryResult
            {
                BlogId=values.BlogId,
                TagCloudId=values.TagCloudId,
                Title=values.Title,
            };
        }
    }
}
