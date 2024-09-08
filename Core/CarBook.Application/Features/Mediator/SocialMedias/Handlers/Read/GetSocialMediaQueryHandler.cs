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
    public class GetSocialMediaQueryHandler : BaseHandler<SocialMedia>, IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository) : base(repository)
        {
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetSocialMediaQueryResult
            {
                IconUrl = x.IconUrl,
                Name = x.Name,
                SocialMediaId = x.SocialMediaId,
                Url=x.Url, 
            }).ToList();
        }
    }
}
