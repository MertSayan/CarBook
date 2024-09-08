using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Pricings.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Pricings.Handlers.Write
{
    public class UpdatePricingCommandHandler : BaseHandler<Pricing>, IRequestHandler<UpdatePricingCommand>
    {
        public UpdatePricingCommandHandler(IRepository<Pricing> repository) : base(repository)
        {
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.PricingId);
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
