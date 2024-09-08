using CarBook.Application.Features.CQRS.Abouts.Queries;
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
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _aboutRepository;

        public GetAboutByIdQueryHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = await _aboutRepository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutId = values.AboutId,
                Description = values.Description,
                ImageUrl = values.ImageUrl,
                Title = values.Title
            };
        }
    }
}
