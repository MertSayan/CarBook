using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Categories.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Categories.Handlers.Read
{
    public class GetCategoryQueryHandler : BaseHandler<Category>
    {
        public GetCategoryQueryHandler(IRepository<Category> repository) : base(repository)
        {
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                Name = x.Name,
                CategoryId = x.CategoryId,
            }).ToList();
        }
    }
}
