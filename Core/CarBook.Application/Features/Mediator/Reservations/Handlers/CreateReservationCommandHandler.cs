using CarBook.Application.Features.Mediator.Reservations.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Reservations.Handlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Age=request.Age,
                CarId=request.CarId,
                Description=request.Description,
                DriverLicenseYear=request.DriverLicenseYear,
                Email=request.Email,
                Name=request.Name,
                Surname=request.Surname,
                PhoneNumber=request.PhoneNumber,
                PickUpLocationId=request.PickUpLocationId,
                DropOffLocationId = request.DropOffLocationId,
                Status="Rezervasyon Alındı"
                
            });
        }
    }
}
