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
    public class CarFeatureAvailableChanteToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChanteToTrueCommand>
    {
        private readonly ICarFetureRepository _repository;

        public CarFeatureAvailableChanteToTrueCommandHandler(ICarFetureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureAvailableChanteToTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToTrue(request.Id);
        }
    }
}
