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
    public class UpdateLocationCommandHandler : BaseHandler<Location>, IRequestHandler<UpdateLocationCommand>
    {
        public UpdateLocationCommandHandler(IRepository<Location> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.LocationId);
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
