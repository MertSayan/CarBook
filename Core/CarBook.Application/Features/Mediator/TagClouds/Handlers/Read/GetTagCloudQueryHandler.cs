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
    public class GetTagCloudQueryHandler : BaseHandler<TagCloud>, IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        public GetTagCloudQueryHandler(IRepository<TagCloud> repository) : base(repository)
        {
        }

        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetTagCloudQueryResult
            {
                BlogId = x.BlogId,
                TagCloudId = x.TagCloudId,
                Title= x.Title,
            }).ToList();
        }
    }
}
