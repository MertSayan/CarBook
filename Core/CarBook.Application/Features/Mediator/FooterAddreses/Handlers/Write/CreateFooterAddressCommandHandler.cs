using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.FooterAddreses.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.FooterAddreses.Handlers.Write
{
    public class CreateFooterAddressCommandHandler : BaseHandler<FooterAdress>, IRequestHandler<CreateFooterAddressCommand>
    {
        public CreateFooterAddressCommandHandler(IRepository<FooterAdress> repository) : base(repository)
        {
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAdress
            {
                Phone = request.Phone,
                Address = request.Address,
                Description = request.Description,
                Email = request.Email,
            });
        }
    }
}
