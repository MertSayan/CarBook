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
    public class CreateFeatureCommandHandler : BaseHandler<Feature>,IRequestHandler<CreateFeatureCommand>
    {
        public CreateFeatureCommandHandler(IRepository<Feature> repository) : base(repository)
        {
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Feature
            {
                Name = request.Name
            });
        }
    }
}
