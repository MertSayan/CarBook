using CarBook.Application.Features.Mediator.AppUsers.Results;
using MediatR;

namespace CarBook.Application.Features.Mediator.AppUsers.Queries
{
	public class GetCheckAppUserQuery : IRequest<GetCheckAppUserQueryResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
