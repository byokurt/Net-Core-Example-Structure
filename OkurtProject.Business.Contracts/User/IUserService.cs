using OkurtProject.Business.DTO;

namespace OkurtProject.Business.Contracts
{
    public interface IUserService
    {
        UserAuthenticationResultDTO Login(string username, string password, bool rememberMe);
    }
}
