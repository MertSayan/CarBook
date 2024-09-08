using CarBook.Application.Features.Mediator.Service.Results;
using MediatR;

namespace CarBook.Application.Features.Mediator.Service.Queries
{
    public class GetServiceQuery:IRequest<List<GetServiceQueryResult>>
    {
    }
}
