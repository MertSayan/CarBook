﻿using CarBook.Application.Features.Mediator.RentACars.Queries;
using CarBook.Application.Features.Mediator.RentACars.Results;
using CarBook.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.RentACars.Handlers
{
    public class GetRentACarQueryHandler:IRequestHandler<GetRentACarQuery,List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
            var results=values.Select(y => new GetRentACarQueryResult
                        {
                            CarId=y.CarId,
                            BrandName=y.Car.Brand.Name,
                            Model=y.Car.Model,
                            CoverImageUrl=y.Car.CoverImageUrl,
                        }).ToList();
            return results;
        }
    }
}
