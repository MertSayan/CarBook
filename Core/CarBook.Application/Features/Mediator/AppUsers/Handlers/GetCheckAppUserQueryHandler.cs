﻿using CarBook.Application.Features.Mediator.AppUsers.Queries;
using CarBook.Application.Features.Mediator.AppUsers.Results;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.AppUsers.Handlers
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IRepository<AppUser> _appUserRepository;
		private readonly IRepository<AppRole> _appRoleRepository;

		public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
		{
			_appUserRepository = appUserRepository;
			_appRoleRepository = appRoleRepository;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = new GetCheckAppUserQueryResult();
			var user=await _appUserRepository.GetByFilterAsync(x=>x.UserName==request.UserName && x.Password==request.Password);
			if(user == null)
			{
				values.IsExist = false;	
			}
			else
			{
				values.IsExist=true;
				values.UserName=user.UserName;
				values.Rol = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId))?.Name;
				values.Id = user.AppUserId;
			}
			return values;
		}
	}
}
