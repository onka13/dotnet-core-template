using DotNetCommon.Application.APIBase.Base;
using Shared.Infrastructure.Helpers;

namespace Shared.ApplicationBase.BaseComponents;

public class SharedTestBase<TStartUp> : TestBase<TStartUp>
    where TStartUp : StartupBase
{
}