using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

namespace CodeSolveNetwork.Api.Configuration.HelthChecks
{
    public class SelfHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            var assembly = Assembly.Load("CodeSolveNetwork.API");
            var versionNumber = assembly.GetName().Version;

            return Task.FromResult(HealthCheckResult.Healthy($"Build {versionNumber}"));
        }
    }
}
