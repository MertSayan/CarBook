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
    public class UpdateSocialMediaQueryHandler : BaseHandler<SocialMedia>, IRequestHandler<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaQueryHandler(IRepository<SocialMedia> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.SocialMediaId);
            value.Url = request.Url;
            value.IconUrl = request.IconUrl;
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
