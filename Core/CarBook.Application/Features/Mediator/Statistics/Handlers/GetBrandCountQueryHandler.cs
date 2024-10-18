﻿using CarBook.Application.Features.Mediator.Statistics.Queries;
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
    public class GetBrandCountQueryHandler: IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetBrandCount();
            return new GetBrandCountQueryResult
            {
                BrandCount=value
            };
        }
    }
}
