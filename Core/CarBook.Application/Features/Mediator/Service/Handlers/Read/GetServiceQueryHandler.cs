using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Service.Queries;
using CarBook.Application.Features.Mediator.Service.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Service.Handlers.Read
{
    public class GetServiceQueryHandler : BaseHandler<Services>, IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        public GetServiceQueryHandler(IRepository<Services> repository) : base(repository)
        {
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                Description = x.Description,
                IconUrl = x.IconUrl,
                ServiceId = x.ServiceId,
                Title= x.Title,
            }).ToList();
        }
    }
}
