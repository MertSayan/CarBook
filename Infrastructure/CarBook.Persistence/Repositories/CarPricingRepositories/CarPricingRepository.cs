﻿using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
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

		public async Task<List<CarPricing>> GetCarPricingWithTimePeriod()
		{
			return null;
		}

		public async Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod1()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _carBookContext.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings " +
									  "Inner Join Cars On Cars.CarID=CarPricings.CarId " +
									  "Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable " +
									  "Pivot (Sum(Amount) For PricingID In ([2],[3],[4])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_carBookContext.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					//,Brands.Name
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							BrandName = reader["Name"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							//BrandName = reader["BrandsName"].ToString(),
							Amounts = new List<decimal>
							{
								Convert.ToDecimal(reader["2"]),
								Convert.ToDecimal(reader["3"]),
								Convert.ToDecimal(reader["4"])
							}
						};
						values.Add(carPricingViewModel);
					
					}
				}
				_carBookContext.Database.CloseConnection();
			}
			return values;
		}
	}
}
