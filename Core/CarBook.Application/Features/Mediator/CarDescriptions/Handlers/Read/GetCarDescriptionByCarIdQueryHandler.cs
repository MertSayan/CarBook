using CarBook.Application.Features.Mediator.CarDescriptions.Queries;
using CarBook.Application.Features.Mediator.CarDescriptions.Results;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.CarDescriptions.Handlers.Read
{
	public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
	{
		private readonly ICarDescriptionRepository _repository;

		public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values =  _repository.GetCarDescription(request.Id);
			return new GetCarDescriptionByCarIdQueryResult
			{
				CarDescriptionId = values.CarDescriptionId,
				CarId = values.CarId,
				Details=values.Details
			};
		}
	}
}
