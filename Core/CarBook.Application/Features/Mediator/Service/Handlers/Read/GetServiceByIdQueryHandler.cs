using CarBook.Application.BaseHandler;
using CarBook.Application.Features.Mediator.Service.Queries;
using CarBook.Application.Features.Mediator.Service.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Service.Handlers.Read
{
    public class GetServiceByIdQueryHandler : BaseHandler<Services>, IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        public GetServiceByIdQueryHandler(IRepository<Services> repository) : base(repository)
        {
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                Description = value.Description,
                IconUrl = value.IconUrl,
                ServiceId = value.ServiceId,
                Title = value.Title
            };
        }
    }
}
