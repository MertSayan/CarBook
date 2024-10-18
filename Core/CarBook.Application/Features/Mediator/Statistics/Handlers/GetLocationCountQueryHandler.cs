using CarBook.Application.Features.Mediator.Statistics.Queries;
using CarBook.Application.Features.Mediator.Statistics.Results;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Statistics.Handlers
{
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetLocationCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetLocationCount();
            return new GetLocationCountQueryResult
            {
                LocationCount= value
            };
        }
    }
}
