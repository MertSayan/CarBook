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
    public class RemovePricingCommandHandler : BaseHandler<Pricing>, IRequestHandler<RemovePricingCommand>
    {
        public RemovePricingCommandHandler(IRepository<Pricing> repository) : base(repository)
        {
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
