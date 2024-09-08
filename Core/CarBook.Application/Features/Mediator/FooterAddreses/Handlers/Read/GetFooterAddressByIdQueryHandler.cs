using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.FooterAddreses.Queries;
using CarBook.Application.Features.Mediator.FooterAddreses.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.FooterAddreses.Handlers.Read
{
    public class GetFooterAddressByIdQueryHandler : BaseHandler<FooterAdress>, IRequestHandler<GetFooterAddressByIdQuery,GetFooterAddressByIdQueryResult>
    {
        public GetFooterAddressByIdQueryHandler(IRepository<FooterAdress> repository) : base(repository)
        {
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
                FooterAdressId = value.FooterAdressId,
                Address =value.Address,
                Description=value.Description,
                Email=value.Email,
                Phone=value.Phone
            };
        }
    }
}
