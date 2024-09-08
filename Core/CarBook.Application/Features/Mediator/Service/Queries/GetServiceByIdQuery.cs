using CarBook.Application.Features.Mediator.Service.Results;
using MediatR;

namespace CarBook.Application.Features.Mediator.Service.Queries
{
    public class GetServiceByIdQuery:IRequest<GetServiceByIdQueryResult>
    {
        public int Id { get; set; }

        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
