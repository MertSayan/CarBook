using CarBook.Application.Features.Mediator.CarFeatures.Commands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.CarFeatures.Handlers.Write
{
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private readonly ICarFetureRepository _repository;

        public CreateCarFeatureByCarCommandHandler(ICarFetureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            _repository.CreateCarFeatureByCar(new Domain.Entities.CarFeature
            {
                Available=false,
                CarId=request.CarId,
                FeatureId=request.FeatureId
            });
        }
    }
}
