using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace OkurtProject.Client.API.Bootstrapper.Authorization
{
    public static class AuthorizationHelper
    {
        public static string GetClaimValue(IPrincipal user, string propertyName)
        {
            var identity = user.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var claims = from c in identity.Claims
                             select new
                             {
                                 subject = c.Subject.Name,
                                 type = c.Type,
                                 value = c.Value
                             };

                var claim = claims.FirstOrDefault(a => a.type == propertyName);

                if (claim != null)
                {
                    return claim.value.ToString();
                }
            }

            return "";
        }
    }
}
