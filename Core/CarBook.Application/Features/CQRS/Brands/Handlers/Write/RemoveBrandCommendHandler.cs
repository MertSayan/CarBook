using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Brands.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Brands.Handlers.Write
{
    public class RemoveBrandCommendHandler : BaseHandler<Brand>
    {
        public RemoveBrandCommendHandler(IRepository<Brand> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveBrandCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
