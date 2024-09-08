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
    public class RemoveLocationCommandHandler : BaseHandler<Location>, IRequestHandler<RemoveLocationCommand>
    {
        public RemoveLocationCommandHandler(IRepository<Location> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
