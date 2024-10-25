using MediatR;

namespace CarBook.Application.Features.Mediator.AppUsers.Commands
{
	public class CreateAppUserCommand:IRequest
	{
		public string UserName { get; set; }

		public string Password { get; set; }
	}
}
