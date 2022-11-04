using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Secyud.Abp.MasaTheme.Shared;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.Common;

public partial class MasaThemeSelector
{
    //TODO(secyud): icon
    [Inject] public IOptions<MasaThemeOptions> ThemeOptions { get; private set; }

    [Inject] public IOptions<MasaThemeBlazorOptions> BlazorOptions { get; private set; }

    [Inject] protected IThemeManager ThemeManager { get; set; }

    [CascadingParameter(Name = "IsDark")] public bool CascadingIsDark { get; set; }

    public async Task ChangeThemeAsync()
    {
        await ThemeManager.ChangeThemeAsync(new ThemeChangeEventArgs
        {
            ThemeName = CascadingIsDark ? MasaStyleNames.Light : MasaStyleNames.Dark
        });
    }
}