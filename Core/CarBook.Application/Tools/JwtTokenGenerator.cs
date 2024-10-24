﻿using CarBook.Application.Dtos;
using CarBook.Application.Features.Mediator.AppUsers.Results;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResult result)
		{
			var claims = new List<Claim>();
			if (!string.IsNullOrWhiteSpace(result.Rol))
			{
				claims.Add(new Claim(ClaimTypes.Role, result.Rol));
			}
			claims.Add(new Claim(ClaimTypes.NameIdentifier,result.Id.ToString()));

			if (!string.IsNullOrWhiteSpace(result.UserName))
			{
				claims.Add(new Claim("Username",result.UserName));
			}
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

			var signinCredentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

			var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

			JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience,
				claims: claims,notBefore:DateTime.UtcNow,expires:expireDate,signingCredentials:signinCredentials);

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
		}
	}
}
