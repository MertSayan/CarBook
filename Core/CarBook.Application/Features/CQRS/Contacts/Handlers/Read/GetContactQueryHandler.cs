using CarBook.Application.BaseHandler;
using CarBook.Application.Features.CQRS.Contacts.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Contacts.Handlers.Read
{
    public class GetContactQueryHandler : BaseHandler<Contact>
    {
        public GetContactQueryHandler(IRepository<Contact> repository) : base(repository)
        {
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                Email = x.Email,
                Message = x.Message,
                Name = x.Name,
                SendDate = x.SendDate,
                Subject = x.Subject
            }).ToList();
        }
    }
}
