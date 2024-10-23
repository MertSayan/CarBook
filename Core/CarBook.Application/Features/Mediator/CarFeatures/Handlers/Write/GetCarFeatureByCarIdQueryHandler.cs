using CarBook.Application.Features.Mediator.CarFeatures.Queries;
using CarBook.Application.Features.Mediator.CarFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.CarFeatures.Handlers.Write
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFetureRepository _repository;

        public GetCarFeatureByCarIdQueryHandler(ICarFetureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarFeaturesByCarId(request.Id);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                Available=x.Available,
                CarFeatureId=x.CarFeatureId,
                FeatureId=x.FeatureId,
                FeatureName=x.Feature.Name,
                
            }).ToList();
        }
    }
}
