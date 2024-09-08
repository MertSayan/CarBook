using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Brands.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Brands.Handlers.Write
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
