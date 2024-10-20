using CarBook.Application.Features.Mediator.CarPricings.Queries;
using CarBook.Application.Features.Mediator.CarPricings.Results;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.CarPricings.Handlers
{
	public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
	{
		private readonly ICarPricingRepository _carPricingRepository;

		public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
		{
			var values = await _carPricingRepository.GetCarPricingWithCars();
			return values.Select(x=> new GetCarPricingWithCarQueryResult
			{
				Amount= x.Amount,
				BrandName=x.Car.Brand.Name,
				CarPricingId=x.CarPricingId,
				CoverImageUrl=x.Car.CoverImageUrl,
				Model=x.Car.Model, 
				CarId=x.CarId
			}).ToList();
		}
	}
}
