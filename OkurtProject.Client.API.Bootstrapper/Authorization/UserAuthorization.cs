using Microsoft.AspNetCore.Authorization;
using OkurtProject.Utils;
using System;
using System.Linq;

namespace OkurtProject.Client.API.Bootstrapper.Authorization
{
    public class UserAuthorization : AuthorizeAttribute
    {
        public UserAuthorization()
        {

        }

        public UserAuthorization(params UserRoles[] roles)
        {
            Roles = string.Join(",", roles.Select(x => Convert.ToInt32(x)).ToArray());
        }
    }
}
