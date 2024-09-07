using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Banners.Queries;
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
    public class GetCarByIdQueryHandler : BaseHandler<Car>
    {
        public GetCarByIdQueryHandler(IRepository<Car> repository) : base(repository)
        {
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                BigImageUrl = value.BigImageUrl,
                BrandId = value.BrandId,
                CarId = value.CarId,
                CoverImageUrl = value.CoverImageUrl,
                Fuel = value.Fuel,
                Km = value.Km,
                Luggage = value.Luggage,
                Model = value.Model,
                Seat = value.Seat,
                Transmission = value.Transmission,
            };
        }
    }
}
