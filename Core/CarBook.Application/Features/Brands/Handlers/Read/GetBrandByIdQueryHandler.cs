using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Brands.Queries;
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
    public class GetBrandByIdQueryHandler : BaseHandler<Brand>
    {
        public GetBrandByIdQueryHandler(IRepository<Brand> repository) : base(repository)
        {
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var value= await _repository.GetByIdAsync(query.Id);
            return new GetBrandByIdQueryResult
            {
                BrandId = value.BrandId,
                Name=value.Name
            };
        }
    }
}
