using CarBook.Application.Features.Mediator.Statistics.Queries;
using CarBook.Application.Features.Mediator.Statistics.Results;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Statistics.Handlers
{
    public class GetCarCountByTransmissionIsAutoQueryHandler :IRequestHandler<GetCarCountByTransmissionIsAutoQuery,GetCarCountByTransmissionIsAutoQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByTransmissionIsAutoQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByTransmissionIsAutoQueryResult> Handle(GetCarCountByTransmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarCountByTransmissionIsAuto();
            return new GetCarCountByTransmissionIsAutoQueryResult
            {
                AutoTransmissionCount=value,
            };
        }
    }
}
