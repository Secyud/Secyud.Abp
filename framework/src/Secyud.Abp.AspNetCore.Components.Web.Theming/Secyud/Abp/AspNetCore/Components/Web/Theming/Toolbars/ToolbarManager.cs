using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming.Toolbars;

public class ToolbarManager : IToolbarManager, ITransientDependency
{
    public ToolbarManager(
        IOptions<AbpToolbarOptions> options,
        IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        Options = options.Value;
    }

    protected AbpToolbarOptions Options { get; }
    protected IServiceProvider ServiceProvider { get; }

    public async Task<Toolbar> GetAsync(string name)
    {
        var toolbar = new Toolbar(name);

        using var scope = ServiceProvider.CreateScope();

        var context = new ToolbarConfigurationContext(toolbar, scope.ServiceProvider);

        foreach (var contributor in Options.Contributors)
            await contributor.ConfigureToolbarAsync(context);

        return toolbar;
    }
}