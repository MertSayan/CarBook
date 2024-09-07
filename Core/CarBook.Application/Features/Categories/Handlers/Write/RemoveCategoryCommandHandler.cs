using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Categories.Command;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Categories.Handlers.Write
{
    public class RemoveCategoryCommandHandler : BaseHandler<Category>
    {
        public RemoveCategoryCommandHandler(IRepository<Category> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var value=await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
