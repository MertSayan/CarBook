using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Features.Queries;
using CarBook.Application.Features.Mediator.Features.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Features.Handlers.Read
{
    public class GetFeatureQueryHandler : BaseHandler<Feature>,IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        public GetFeatureQueryHandler(IRepository<Feature> repository) : base(repository)
        {
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                Name= x.Name
            }).ToList();
        }
    }
}
