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
    public class GetCarCountBuFuelGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountBuFuelGasolineOrDieselQuery, GetCarCountBuFuelGasolineOrDieselQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountBuFuelGasolineOrDieselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountBuFuelGasolineOrDieselQueryResult> Handle(GetCarCountBuFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarCountBuFuelGasolineOrDiesel();
            return new GetCarCountBuFuelGasolineOrDieselQueryResult
            {
                GasolineOrDizelCount=value
            };
        }
    }
}
