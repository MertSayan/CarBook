using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Service.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Service.Handlers.Write
{
    public class RemoveServiceCommandHandler : BaseHandler<Services>, IRequestHandler<RemoveServiceCommand>
    {
        public RemoveServiceCommandHandler(IRepository<Services> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
