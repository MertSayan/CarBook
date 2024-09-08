using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Locations.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Locations.Handlers.Write
{
    public class CreateLocationCommandHandler : BaseHandler<Location>, IRequestHandler<CreateLocationCommand>
    {
        public CreateLocationCommandHandler(IRepository<Location> repository) : base(repository)
        {
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Location
            {
                Name = request.Name,
            });
        }
    }
}
