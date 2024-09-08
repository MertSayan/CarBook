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
    public class UpdateCategoryCommandHandler : BaseHandler<Category>
    {
        public UpdateCategoryCommandHandler(IRepository<Category> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateCategoryCommand command, int id)
        {
            var value = await _repository.GetByIdAsync(id);
            value.Name = command.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
