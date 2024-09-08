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
    public class CreateServiceCommandHandler : BaseHandler<Services>, IRequestHandler<CreateServiceCommand>
    {
        public CreateServiceCommandHandler(IRepository<Services> repository) : base(repository)
        {
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Services
            {
                Title = request.Title,
                IconUrl = request.IconUrl,
                Description = request.Description,
                
            });
        }
    }
}
