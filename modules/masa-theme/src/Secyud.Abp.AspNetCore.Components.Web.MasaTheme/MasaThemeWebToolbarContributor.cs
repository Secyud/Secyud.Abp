using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.Common;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme
{
    public class MasaThemeWebToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name == StandardToolbars.Main)
            {
                var options = context.ServiceProvider.GetRequiredService<IOptions<MasaThemeBlazorOptions>>().Value;

                context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSelector)));
                context.Toolbar.Items.Add(new ToolbarItem(typeof(ThemeSelecter)));
            }

            return Task.CompletedTask;
        }
    }
}
