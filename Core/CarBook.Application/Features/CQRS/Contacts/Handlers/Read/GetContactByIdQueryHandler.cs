using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Contacts.Queries;
using CarBook.Application.Features.CQRS.Contacts.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Contacts.Handlers.Read
{
    public class GetContactByIdQueryHandler : BaseHandler<Contact>
    {
        public GetContactByIdQueryHandler(IRepository<Contact> repository) : base(repository)
        {
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = value.ContactId,
                Email = value.Email,
                Message = value.Message,
                Name = value.Name,
                SendDate = value.SendDate,
                Subject = value.Subject
            };
        }
    }
}
