using CarBook.Application.Features.Mediator.Pricings.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Pricings.Results
{
    public class GetPricingQueryResult
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
    }
}
