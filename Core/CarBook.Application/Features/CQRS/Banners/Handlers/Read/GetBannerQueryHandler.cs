using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Banners.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Banners.Handlers.Read
{
    public class GetBannerQueryHandler : BaseHandler<Banner>
    {
        public GetBannerQueryHandler(IRepository<Banner> repository) : base(repository)
        {
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                Title = x.Title,
                Description = x.Description,
                VideoUrl = x.VideoUrl,
                VideoDescription = x.VideoDescription,
            }).ToList();
        }
    }
}
