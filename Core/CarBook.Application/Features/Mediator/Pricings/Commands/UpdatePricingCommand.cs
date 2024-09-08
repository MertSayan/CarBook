using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Pricings.Commands
{
    public class UpdatePricingCommand:IRequest
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
    }

    public class UpdatePricingCommandDTO
    {
        public string Name { get; set; }
    }
}
