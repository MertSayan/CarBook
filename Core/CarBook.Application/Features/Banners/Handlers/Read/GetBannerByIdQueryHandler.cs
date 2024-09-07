using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Banners.Queries;
using CarBook.Application.Features.Banners.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Banners.Handlers.Read
{
    public class GetBannerByIdQueryHandler : BaseHandler<Banner>
    {
        public GetBannerByIdQueryHandler(IRepository<Banner> repository) : base(repository)
        {
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value=await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerId = value.BannerId,
                Title = value.Title,
                Description = value.Description,
                VideoUrl = value.VideoUrl,
                VideoDescription = value.VideoDescription
            };
        }
    }
}
