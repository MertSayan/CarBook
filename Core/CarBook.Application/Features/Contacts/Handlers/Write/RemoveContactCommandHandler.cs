using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Contacts.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Contacts.Handlers.Write
{
    public class RemoveContactCommandHandler : BaseHandler<Contact>
    {
        public RemoveContactCommandHandler(IRepository<Contact> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var value= await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
