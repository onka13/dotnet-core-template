using DotNetCommon.Application.WebAPIBase.Base;
using Shared.Infrastructure.Helpers;

namespace Shared.ApplicationWebBase.BaseComponents;

public class SharedStartupWebBase : StartupWebBase
{
    public SharedStartupWebBase()
    {
        Origins = new string[]
        {
            "http://localhost:8080",
            "http://localhost:3001",
            "http://localhost:3002",
        };
    }

    public override string EnvironmentName(string? env = null)
    {
        EnvironmentHelper.SetAppEnvironment(EnvironmentHelper.GetEnvironment(env));
        return EnvironmentHelper.GetEnvironment().ToString().ToLowerInvariant();
    }
}