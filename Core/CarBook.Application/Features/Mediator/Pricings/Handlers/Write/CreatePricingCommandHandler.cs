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
    public class CreatePricingCommandHandler : BaseHandler<Pricing>, IRequestHandler<CreatePricingCommand>
    {
        public CreatePricingCommandHandler(IRepository<Pricing> repository) : base(repository)
        {
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Pricing
            {
                Name = request.Name
            });
        }
    }
}
