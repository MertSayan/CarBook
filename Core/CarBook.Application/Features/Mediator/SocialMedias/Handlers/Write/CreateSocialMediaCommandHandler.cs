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
    public class CreateSocialMediaCommandHandler : BaseHandler<SocialMedia>, IRequestHandler<CreateSocialMediaCommand>
    {
        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository) : base(repository)
        {
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new SocialMedia
            {
                Url = request.Url,
                Name = request.Name,
                IconUrl = request.IconUrl,
                
            });
        }
    }
}
