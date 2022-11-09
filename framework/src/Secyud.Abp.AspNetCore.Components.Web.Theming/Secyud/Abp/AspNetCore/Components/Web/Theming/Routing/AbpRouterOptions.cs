using System.Reflection;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming.Routing;

public class AbpRouterOptions
{
    public AbpRouterOptions()
    {
        AdditionalAssemblies = new RouterAssemblyList();
    }

    public Assembly AppAssembly { get; set; }

    public RouterAssemblyList AdditionalAssemblies { get; }
}