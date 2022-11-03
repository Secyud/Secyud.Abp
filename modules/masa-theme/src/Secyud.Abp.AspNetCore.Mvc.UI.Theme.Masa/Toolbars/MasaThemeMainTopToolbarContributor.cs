using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Toolbars;

public class MasaThemeMainTopToolbarContributor : IToolbarContributor
{
    public async Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name != StandardToolbars.Main)
        {
            return;
        }

        if (!(context.Theme is MasaTheme))
        {
            return;
        }

        var options = context.ServiceProvider.GetRequiredService<IOptions<MasaThemeMvcOptions>>();


    }
}
