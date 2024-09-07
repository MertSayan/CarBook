using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Brands.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Brands.Handlers.Read
{
    public class GetBrandQueryHandler : BaseHandler<Brand>
    {
        public GetBrandQueryHandler(IRepository<Brand> repository) : base(repository)
        {
        }

        public async Task<List<GetBrandByIdQueryResult>> Handle()
        {
            var values=await _repository.GetAllAsync();
            return values.Select(x => new GetBrandByIdQueryResult
            {
                BrandId = x.BrandId,
                Name= x.Name
            }).ToList();
        }
    }
}
