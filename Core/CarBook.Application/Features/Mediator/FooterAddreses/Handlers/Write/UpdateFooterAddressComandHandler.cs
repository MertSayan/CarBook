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
    public class UpdateFooterAddressComandHandler : BaseHandler<FooterAdress>, IRequestHandler<UpdateFooterAddressCommand>
    {
        public UpdateFooterAddressComandHandler(IRepository<FooterAdress> repository) : base(repository)
        {
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.FooterAdressId);
            value.Description=request.Description;
            value.Address=request.Address;
            value.Phone=request.Phone;
            value.Email=request.Email;
            await _repository.UpdateAsync(value);
        }
    }
}
