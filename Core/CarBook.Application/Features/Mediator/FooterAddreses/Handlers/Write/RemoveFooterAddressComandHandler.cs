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
    public class RemoveFooterAddressComandHandler : BaseHandler<FooterAdress>, IRequestHandler<RemoveFooterAddressCommand>
    {
        public RemoveFooterAddressComandHandler(IRepository<FooterAdress> repository) : base(repository)
        {
        }

        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
