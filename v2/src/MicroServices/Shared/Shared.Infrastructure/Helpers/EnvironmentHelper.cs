using DotNetCommon.Data.Domain.Models;
using Shared.Domain.Business;

namespace Shared.Infrastructure.Helpers;

public static class EnvironmentHelper
{
    public static AppEnvironment AppEnvironment { get; private set; }

    public static void SetAppEnvironment(AppEnvironment env)
    {
        AppEnvironment = env;
    }

    public static AppEnvironment GetEnvironment(string? environment = null)
    {
        if (string.IsNullOrWhiteSpace(environment))
        {
            environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        switch (environment?.ToLowerInvariant())
        {
            case "dev":
            case "debug":
            case "development":
                return AppEnvironment.Development;
            case "staging":
                return AppEnvironment.Staging;
            case "live":
            case "prod":
            case "release":
            case "production":
                return AppEnvironment.Live;
        }

        throw new AppException("Unknown environment");
    }
}
