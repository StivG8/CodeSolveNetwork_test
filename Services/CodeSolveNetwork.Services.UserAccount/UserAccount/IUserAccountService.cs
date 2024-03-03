
namespace CodeSolveNetwork.Services.UserAccount
{
    public interface IUserAccountService
    {
        Task<bool> IsEmpty();

        /// <summary>
        /// Create user account
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserAccountModel> Create(RegisterUserAccountModel model);




        // Also we can place methods here for changing account information, recovering and changing passwords, confirming email, setting up a phone and confirming it, etc.
    }
}
