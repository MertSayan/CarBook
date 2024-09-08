using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.SocialMedias.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.SocialMedias.Handlers.Write
{
    public class RemoveSocialMediaQueryHandler : BaseHandler<SocialMedia>, IRequestHandler<RemoveSocialMediaCommand>
    {
        public RemoveSocialMediaQueryHandler(IRepository<SocialMedia> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
