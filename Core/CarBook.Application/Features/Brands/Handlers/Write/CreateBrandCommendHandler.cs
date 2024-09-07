using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Banners.Commands;
using CarBook.Application.Features.Brands.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Brands.Handlers.Write
{
    public class CreateBrandCommendHandler : BaseHandler<Brand>
    {
        public CreateBrandCommendHandler(IRepository<Brand> repository) : base(repository)
        {
        }

        public async Task Handle(CreateBrandCommand command)
        {
            await _repository.CreateAsync(new Brand
            {
                Name = command.Name,
            });
        }
    }
}
