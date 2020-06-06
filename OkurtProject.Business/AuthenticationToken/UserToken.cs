using OkurtProject.Business.DTO;
using OkurtProject.Utils;
using OkurtProject.Utils.Constants;
using System.Security.Claims;

namespace OkurtProject.Business.AuthenticationToken
{
    public class CompanyUserToken : AuthenticationToken
    {
        public CompanyUserToken(UserAuthenticationDTO user, Appsettings appSettings, bool rememberMe) : base(user, appSettings, rememberMe)
        {
            _claims.Add(new Claim(ApplicationConstants.ClaimId, _user.Id.ToString()));
        }
    }
}
