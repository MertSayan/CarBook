using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Abouts.Commands;
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
    public class UpdateContactCommandHandler : BaseHandler<Contact>
    {
        public UpdateContactCommandHandler(IRepository<Contact> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateContactCommand command,int id)
        {
            var value=await _repository.GetByIdAsync(id);
            value.SendDate = DateTime.Now;
            value.Subject=command.Subject;
            value.Email=command.Email;
            value.Message=command.Message;
            value.Name=command.Name;
            await _repository.UpdateAsync(value);
            
        }
    }
}
