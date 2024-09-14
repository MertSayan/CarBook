using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _carBookContext;

		public CarPricingRepository(CarBookContext carBookContext)
		{
			_carBookContext = carBookContext;
		}

		public async Task<List<CarPricing>> GetCarPricingWithCars()
		{
			var values=_carBookContext.CarPricings.Include(x=>x.Car).ThenInclude(y=>y.Brand).Include(z=>z.Pricing).Where(a=>a.PricingId==3).ToList();
			return values;
		}
	}
}
