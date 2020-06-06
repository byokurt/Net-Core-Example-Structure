using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkurtProject.Client.API.Bootstrapper.Authorization;
using OkurtProject.Utils;
using OkurtProject.Utils.Constants;
using System;
using System.Security.Claims;

namespace OkurtProject.Client.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[UserAuthorization(UserRoles.User)]
    public class BaseUserController : ControllerBase
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IHttpContextAccessor _httpContext;

        private int? _userId;
        private int? _roleId;
        private UserCredentials _credentials;
        private string _ipAddress;

        public BaseUserController()
        {

        }

        public BaseUserController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BaseUserController(IServiceProvider serviceProvider, IHttpContextAccessor httpContext)
        {
            _serviceProvider = serviceProvider;
            _httpContext = httpContext;
        }

        public int UserId
        {
            get
            {
                if (!_userId.HasValue)
                    _userId = int.Parse(AuthorizationHelper.GetClaimValue(this.User, ApplicationConstants.ClaimId));
                return _userId.Value;
            }
        }

        public UserRoles Role
        {
            get
            {
                if (!_roleId.HasValue)
                    _roleId = int.Parse(AuthorizationHelper.GetClaimValue(this.User, ClaimTypes.Role));
                return (UserRoles)_roleId.Value;

            }
        }

        public string IPAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_ipAddress))
                    _ipAddress = _httpContext.HttpContext.Connection.RemoteIpAddress.ToString();
                return _ipAddress;
            }
        }

        public UserCredentials Credentials
        {
            get
            {
                if (_credentials == null)

                    _credentials = new UserCredentials()
                    {
                        Role = Role,
                        UserId = UserId,
                    };

                return _credentials;
            }
        }
    }
}