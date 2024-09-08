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
    public class RemoveFeatureCommandHandler :BaseHandler<Feature>, IRequestHandler<RemoveFeatureCommand>
    {
        public RemoveFeatureCommandHandler(IRepository<Feature> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
