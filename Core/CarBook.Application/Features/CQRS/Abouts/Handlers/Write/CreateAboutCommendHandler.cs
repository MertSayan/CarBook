using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Abouts.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Abouts.Handlers.Write
{
    public class CreateAboutCommendHandler : BaseHandler<About>
    {
        public CreateAboutCommendHandler(IRepository<About> repository) : base(repository)
        {
        }

        public async Task Handle(CreateAboutCommand command)
        {
            await _repository.CreateAsync(new About
            {
                Description = command.Description,
                ImageUrl = command.ImageUrl,
                Title = command.Title,
            });
        }
    }
}
