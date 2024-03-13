using CodeSolveNetwork.Web.Pages.Auth.Models;

namespace CodeSolveNetwork.Web.Pages.Auth.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}
