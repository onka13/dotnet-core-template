using DotNetCommon.Application.APIBase.Base;
using Shared.Infrastructure.Helpers;

namespace Shared.ApplicationBase.BaseComponents;

public class SharedStartupBase : StartupBase
{
    public override string EnvironmentName(string? env = null)
    {
        EnvironmentHelper.SetAppEnvironment(EnvironmentHelper.GetEnvironment(env));
        return EnvironmentHelper.GetEnvironment().ToString().ToLowerInvariant();
    }
}