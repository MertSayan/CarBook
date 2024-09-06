using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Abouts.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Abouts.Handlers.Write
{
    public class UpdateAboutCommandHandler : BaseHandler<About>
    {
        public UpdateAboutCommandHandler(IRepository<About> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateAboutCommand command, int id)
        {
            var values = await _repository.GetByIdAsync(id);
            values.Description = command.Description;
            values.Title = command.Title;
            values.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
