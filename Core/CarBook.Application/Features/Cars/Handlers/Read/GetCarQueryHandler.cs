using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Banners.Queries;
using CarBook.Application.Features.Banners.Results;
using CarBook.Application.Features.Cars.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Handlers.Read
{
    public class GetCarQueryHandler : BaseHandler<Car>
    {
        public GetCarQueryHandler(IRepository<Car> repository) : base(repository)
        {
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
                CarId = x.CarId,
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
