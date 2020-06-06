using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkurtProject.Client.DTO;
using Microsoft.Extensions.DependencyInjection;
using OkurtProject.Business.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace OkurtProject.Client.API.Controllers.User
{
    [Route("user")]
    public class UserController : BaseUserController
    {
        public UserController(IServiceProvider serviceProvider, IHttpContextAccessor httpContext) : base(serviceProvider, httpContext)
        {

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public LoginResponseDTO Login(LoginRequestDTO request)
        {
            var loginDetail = _serviceProvider.GetService<IUserService>().Login(request.Username, request.Password, request.RememberMe);

            return new LoginResponseDTO() { Email = loginDetail.Email, Id = loginDetail.Id, Name = loginDetail.Name, Surname = loginDetail.Surname, Token = loginDetail.Token, UserName = loginDetail.Surname };
        }
    }
}