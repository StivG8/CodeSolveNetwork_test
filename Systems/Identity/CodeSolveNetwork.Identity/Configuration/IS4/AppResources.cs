using Duende.IdentityServer.Models;

namespace CodeSolveNetwork.Identity.Configuration
{
    public static class AppResources
    {
        public static IEnumerable<ApiResource> Resources => new List<ApiResource>
        {
            new ApiResource("api")
        };
    }

}
