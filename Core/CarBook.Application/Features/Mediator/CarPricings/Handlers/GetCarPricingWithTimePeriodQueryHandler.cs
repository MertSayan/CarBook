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
	public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarPricingWithTimePeriod1();
			return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
			{
				Model = x.Model,
				Brand=x.BrandName,
				CoverImageUrl = x.CoverImageUrl,
				//BrandName=x.BrandName,
				DailyAmount = x.Amounts[0],
				WeeklyAmount = x.Amounts[1],
				MonthlyAmount = x.Amounts[2],
			}).ToList();
		}
	}
}
