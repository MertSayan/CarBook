﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.CarPricings.Results
{
	public class GetCarPricingWithCarQueryResult
	{
		public int CarId { get; set; }
		public int CarPricingId { get; set; }
		public string BrandName { get; set; }
		public string Model {  get; set; }
		public decimal Amount { get; set; }
		public string CoverImageUrl { get; set; }
	}
}
