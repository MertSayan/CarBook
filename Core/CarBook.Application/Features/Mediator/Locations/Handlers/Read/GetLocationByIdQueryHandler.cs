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
    public class GetLocationByIdQueryHandler : BaseHandler<Location>, IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        public GetLocationByIdQueryHandler(IRepository<Location> repository) : base(repository)
        {
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var values= await _repository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResult
            {
                LocationId = values.LocationId,
                Name= values.Name,
            };
        }
    }
}
