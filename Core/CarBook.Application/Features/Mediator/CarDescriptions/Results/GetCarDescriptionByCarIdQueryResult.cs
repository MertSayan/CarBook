using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.CarDescriptions.Results
{
	public class GetCarDescriptionByCarIdQueryResult
	{
		public int CarDescriptionId { get; set; }
		public int CarId { get; set; }
		public string Details { get; set; }
	}
}
