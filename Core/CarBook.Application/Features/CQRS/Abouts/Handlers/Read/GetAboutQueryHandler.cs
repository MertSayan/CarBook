using CarBook.Application.Features.CQRS.Abouts.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Abouts.Handlers.Read
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _aboutRepository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _aboutRepository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _aboutRepository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                AboutId = x.AboutId,
                Description = x.Description,
                Title = x.Title,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
