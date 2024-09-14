using CarBook.Application.Features.Mediator.CarPricings.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.CarPricings.Queries
{
	public class GetCarPricingWithCarQuery:IRequest<List<GetCarPricingWithCarQueryResult>>
	{

	}
}
