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
    public class GetFooterAddressQueryHandler : BaseHandler<FooterAdress>, IRequestHandler<GetFooterAddressQuery, List<GetFooterAddresQueryResult>>
    {
        public GetFooterAddressQueryHandler(IRepository<FooterAdress> repository) : base(repository)
        {
        }

        public async Task<List<GetFooterAddresQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddresQueryResult
            {
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                FooterAdressId = x.FooterAdressId,
                Phone = x.Phone
            }).ToList();
        }
    }
}
