﻿using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Cars.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Cars.Handlers.Write
{
    public class UpdateCarCommandHandler : BaseHandler<Car>
    {
        public UpdateCarCommandHandler(IRepository<Car> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarId);
            value.Fuel = command.Fuel;
            value.Transmission = command.Transmission;
            value.BigImageUrl = command.BigImageUrl;
            value.BrandId = command.BrandId;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Km = command.Km;
            value.Luggage = command.Luggage;
            value.Model = command.Model;
            value.Seat = command.Seat;
            await _repository.UpdateAsync(value);
        }
    }
}
