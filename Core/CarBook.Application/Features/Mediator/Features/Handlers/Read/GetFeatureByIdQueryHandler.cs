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
    public class GetFeatureByIdQueryHandler : BaseHandler<Feature>, IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        public GetFeatureByIdQueryHandler(IRepository<Feature> repository) : base(repository)
        {
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult
            {
                FeatureId=value.FeatureId,
                Name=value.Name
            };
        }
    }
}
