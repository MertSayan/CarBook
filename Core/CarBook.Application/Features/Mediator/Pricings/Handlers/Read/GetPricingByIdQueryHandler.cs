using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Pricings.Queries;
using CarBook.Application.Features.Mediator.Pricings.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Pricings.Handlers.Read
{
    public class GetPricingByIdQueryHandler : BaseHandler<Pricing>, IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        public GetPricingByIdQueryHandler(IRepository<Pricing> repository) : base(repository)
        {
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult
            {
                Name= value.Name,
                PricingId= value.PricingId,
            }; 
        }
    }
}
