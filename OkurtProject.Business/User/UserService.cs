using Microsoft.Extensions.Options;
using OkurtProject.Business.AuthenticationToken;
using OkurtProject.Business.Contracts;
using OkurtProject.Business.DTO;
using OkurtProject.Utils;
using System;

namespace OkurtProject.Business
{
    public class UserService : BaseService, IUserService
    {
        private readonly Appsettings _appSettings;

        public UserService(IServiceProvider serviceProvider, IOptions<Appsettings> appSettings) : base(serviceProvider)
        {
            _appSettings = appSettings.Value;
        }

        public UserAuthenticationResultDTO Login(string username, string password, bool rememberMe)
        {
            var user = new UserAuthenticationDTO()
            {
                Id = 1,
                Name = "Osman",
                Surname = "KURT",
                Email = "info@osmankurt.net",
                UserName = "osmank",
                RoleId = 1
            };

            var token = new CompanyUserToken(user, _appSettings, rememberMe).Create();

            return new UserAuthenticationResultDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                Token = token,
                CreationDate = DateTime.Now
            };
        }
    }
}
