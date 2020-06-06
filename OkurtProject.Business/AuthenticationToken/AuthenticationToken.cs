using Microsoft.IdentityModel.Tokens;
using OkurtProject.Business.DTO;
using OkurtProject.Utils;
using OkurtProject.Utils.Constants;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OkurtProject.Business.AuthenticationToken
{
    public abstract class AuthenticationToken
    {
        protected BaseUserAuthenticationDTO _user;
        protected IList<Claim> _claims;
        protected readonly Appsettings _appSettings;
        protected readonly bool _rememberMe;

        public AuthenticationToken(BaseUserAuthenticationDTO user, Appsettings appSettings, bool rememberMe)
        {
            _user = user;

            _appSettings = appSettings;

            _claims = new List<Claim>
            {
                    new Claim(ApplicationConstants.ClaimId, _user.Id.ToString()),
                    new Claim(ApplicationConstants.ClaimName, _user.Name.ToString()),
                    new Claim(ApplicationConstants.ClaimEmail, _user.Email.ToString()),
                    new Claim(ClaimTypes.Role, _user.RoleId.ToString())
            };

            _rememberMe = rememberMe;
        }

        public virtual string Create()
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var expireDayCount = ApplicationConstants.TokenDefaultExpireDayCount;

            if (_rememberMe)
            {
                expireDayCount = ApplicationConstants.TokenMaxExpireDayCount;
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(_claims),
                Expires = DateTime.UtcNow.AddDays(expireDayCount),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
