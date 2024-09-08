using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Pricings.Queries;
using CarBook.Application.Features.Mediator.Pricings.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Pricings.Handlers.Read
{
    public class GetPricingQueryHandler : BaseHandler<Pricing>, IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        public GetPricingQueryHandler(IRepository<Pricing> repository) : base(repository)
        {
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetPricingQueryResult
            {
                Name = x.Name,
                PricingId=x.PricingId,
            }).ToList();
        }
    }
}
