using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Categories.Command;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Categories.Handlers.Write
{
    public class CreateCategoryCommandHandler : BaseHandler<Category>
    {
        public CreateCategoryCommandHandler(IRepository<Category> repository) : base(repository)
        {
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            await _repository.CreateAsync(new Category
            {
                Name = command.Name
            });
        }
    }
}
