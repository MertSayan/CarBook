using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Locations.Queries;
using CarBook.Application.Features.Mediator.Locations.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Locations.Handlers.Read
{
    public class GetLocationQueryHandler : BaseHandler<Location>, IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        public GetLocationQueryHandler(IRepository<Location> repository) : base(repository)
        {
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetLocationQueryResult
            {
                LocationId = x.LocationId,
                Name= x.Name,
            }).ToList();
        }
    }
}
