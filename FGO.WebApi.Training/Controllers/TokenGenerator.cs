using FGO.WebApi.Domain.Entities.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;

namespace FGO.WebApi.Training.Controllers
{
    internal class TokenGenerator
    {
        private readonly IOptions<TokenDataModel> config;
        public TokenGenerator(IOptions<TokenDataModel> options)
        {
            config = options;
        }
        public string GenerateTokenJwt(string username)
        {
            var secretKey =  config.Value.JWT_SECRET_KEY;
            var audienceToken = config.Value.JWT_AUDIENCE_TOKEN;
            var issuerToken = config.Value.JWT_ISSUER_TOKEN;
            var expireTime = config.Value.JWT_EXPIRE_MINUTES;

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}
