using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Secyud.Abp.MasaTheme.Shared;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.Common;

public partial class ThemeSelecter
{
    [Inject] public IOptions<MasaThemeOptions> ThemeOptions { get; private set; }

    [Inject] public IOptions<MasaThemeBlazorOptions> BlazorOptions { get; private set; }

    [Inject] protected MasaThemeManager MasaThemeManager { get; set; }

    [CascadingParameter(Name = "IsDark")] public bool CascadingIsDark { get; set; }

    public async Task ChangeTheme()
    {
        await MasaThemeManager.ChangeThemeAsync(new()
        {
            ThemeName = CascadingIsDark ? MasaStyleNames.Light : MasaStyleNames.Dark
        });
    }
}