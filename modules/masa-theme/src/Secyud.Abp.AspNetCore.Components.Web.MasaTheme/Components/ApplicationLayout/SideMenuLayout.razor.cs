using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Secyud.Abp.MasaTheme.Shared;
using Volo.Abp.AspNetCore.Components.Web;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout;

public partial class SideMenuLayout
{
    
    [Inject] protected IAbpUtilsService UtilsService { get; set; }

    [Inject] protected IOptions<MasaThemeOptions> Options { get; set; }
        
    [Inject] protected MasaThemeManager MasaThemeManager { get; set; }
    
    public bool CascadingIsDark { get; set; }

    public SideMenuLayout()
    {
        MasaThemeManager.ThemeChangeEvent += ChangeTheme;
    }
    public async Task ChangeTheme(object sender, MasaThemeChangeEventArgs args)
    {
        CascadingIsDark = args.ThemeName == MasaStyleNames.Dark;
        await InvokeAsync(StateHasChanged);
    }
    
    public void Dispose()
    {
        MasaThemeManager.ThemeChangeEvent -= ChangeTheme;
    }
}
