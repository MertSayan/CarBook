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
    public class RemoveAboutCommandHandler : BaseHandler<About>
    {
        public RemoveAboutCommandHandler(IRepository<About> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveAboutCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
