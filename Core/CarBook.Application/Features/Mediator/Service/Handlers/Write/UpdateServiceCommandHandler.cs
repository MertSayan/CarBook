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
    public class UpdateServiceCommandHandler : BaseHandler<Services>, IRequestHandler<UpdateServiceCommand>
    {
        public UpdateServiceCommandHandler(IRepository<Services> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.ServiceId);
            value.Description = request.Description;
            value.IconUrl = request.IconUrl;
            value.Title = request.Title;
            await _repository.UpdateAsync(value);
        }
    }
}
