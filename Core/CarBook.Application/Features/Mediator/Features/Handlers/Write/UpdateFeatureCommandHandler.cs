using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Features.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Features.Handlers.Write
{
    public class UpdateFeatureCommandHandler : BaseHandler<Feature>,IRequestHandler<UpdateFeatureCommand>
    {
        public UpdateFeatureCommandHandler(IRepository<Feature> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FeatureId);
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
