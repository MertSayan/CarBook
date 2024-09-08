using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.SocialMedias.Queries;
using CarBook.Application.Features.Mediator.SocialMedias.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.SocialMedias.Handlers.Read
{
    public class GetSocialMediaByIdQueryHandler : BaseHandler<SocialMedia>, IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository) : base(repository)
        {
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaId=value.SocialMediaId,
                IconUrl=value.IconUrl,
                Name=value.Name,
                Url = value.Url
            };
        }
    }
}
