using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Cars.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Cars.Handlers.Write
{
    public class RemoveCarCommendHandler : BaseHandler<Car>
    {
        public RemoveCarCommendHandler(IRepository<Car> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
