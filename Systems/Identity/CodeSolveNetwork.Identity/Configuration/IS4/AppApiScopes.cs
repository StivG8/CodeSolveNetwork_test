using CodeSolveNetwork.Common.Security;
using Duende.IdentityServer.Models;

namespace CodeSolveNetwork.Identity.Configuration
{
    public static class AppApiScopes
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope(AppScopes.ProgrammingLanguagesRead, "Read"),
            new ApiScope(AppScopes.ProgrammingLanguagesWrite, "Write")
            };
    }
}
