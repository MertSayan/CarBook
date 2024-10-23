using CarBook.Application.Features.Mediator.CarFeatures.Commands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.CarFeatures.Handlers.Write
{
    public class CarFeatureAvailableChanteToFalseCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChanteToFalseCommand>
    {
        private readonly ICarFetureRepository _repository;

        public CarFeatureAvailableChanteToFalseCommandHandler(ICarFetureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureAvailableChanteToFalseCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToFalse(request.Id);
        }
    }
}
