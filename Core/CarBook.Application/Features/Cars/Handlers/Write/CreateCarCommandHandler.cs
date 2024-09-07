using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Cars.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Handlers.Write
{
    public class CreateCarCommandHandler : BaseHandler<Car>
    {
        public CreateCarCommandHandler(IRepository<Car> repository) : base(repository)
        {
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BigImageUrl = command.BigImageUrl,
                Luggage=command.Luggage,
                Km=command.Km,
                Model=command.Model,
                Seat=command.Seat,
                Transmission=command.Transmission,
                CoverImageUrl=command.CoverImageUrl,
                BrandId=command.BrandId,
                Fuel=command.Fuel,
                
                
            });
        }
    }
}
