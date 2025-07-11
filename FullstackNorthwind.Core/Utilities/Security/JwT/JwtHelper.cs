﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.Entities.Concrete;
using FullstackNorthwind.Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FullstackNorthwind.Core.Utilities.Security.JwT;
public class JwtHelper : ITokenHelper
{
	public IConfiguration Configuration { get; }
	private TokenOptions _tokenOptions;
	private DateTime _accessTokenExpiration;

	public JwtHelper(IConfiguration configuration)
	{
		Configuration = configuration;
		_tokenOptions = Configuration.GetSection("TokenOptions").GetReloadToken<TokenOptions>();
		_accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
	}
	public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
	{
		var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
		var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
	}

	public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
		SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
	{
		var jwt = new JwtSecurityToken(
						issuer: tokenOptions.Issuer,
									audience: tokenOptions.Audience,
									expires: _accessTokenExpiration,
									notBefore: DateTime.Now,
									claims: SetClaims(user, operationClaims),
									signingCredentials: signingCredentials
								);
		return jwt;
	}

	private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
	{
		var claims = new List<Claim>();
		claims.Add(new Claim("email",user.Email));
		claims.AddNameIdentifier(user.Id.ToString());
		claims.AddEmail(user.Email);
		claims.AddName($"{user.FirstName} {user.LastName}");
		claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
		return claims;
	}
}
