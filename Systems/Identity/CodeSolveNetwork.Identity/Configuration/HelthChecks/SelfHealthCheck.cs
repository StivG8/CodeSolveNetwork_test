﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

namespace CodeSolveNetwork.Identity.Configuration
{
    public class SelfHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var assembly = Assembly.Load("CodeSolveNetwork.Identity");
            var versionNumber = assembly.GetName().Version;

            return Task.FromResult(HealthCheckResult.Healthy(description: $"Build {versionNumber}"));
        }
    }
}
