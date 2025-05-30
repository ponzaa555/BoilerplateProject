using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Contract.Authentication;
using Application.Contract.Datetime;
using Domain.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InfraStructure.helper.JwtToken
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSetting _jwtSetting;
        private readonly IDateTimeProvider _dateTimeProvider;
        // private readonly IDateTimeProvider _dateTimeProvider;
        public JwtTokenGenerator( IOptions<JwtSetting> jwtSetting , IDateTimeProvider dateTimeProvider)
        {
             Console.WriteLine("🔧 JwtTokenGenerator initialized with settings:");
            _jwtSetting = jwtSetting.Value;
            _dateTimeProvider = dateTimeProvider;
        }
        public string GenerateToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtSetting.Secret));
            var signingCredentials = new SigningCredentials(secretKey , SecurityAlgorithms.HmacSha256);
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub ,  user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email , user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName , user.FirstName + user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
            };
            var securityToken  = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                claims: claims,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSetting.ExpiryMinuts),
                signingCredentials : signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}