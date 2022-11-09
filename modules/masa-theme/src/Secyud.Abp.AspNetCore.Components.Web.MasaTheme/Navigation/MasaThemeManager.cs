using System;
using System.Threading.Tasks;
using Secyud.Abp.MasaTheme.Shared;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.DependencyInjection;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;

[Dependency(ReplaceServices = true)]
public class MasaThemeManager : IThemeManager, IScopedDependency
{
    private const string CookieName = "masatheme.style";

    private readonly ICookieService _cookieService;

    private string _theme = MasaStyleNames.Light;

    public MasaThemeManager(ICookieService cookieService)
    {
        _cookieService = cookieService;
    }

    public async Task ChangeThemeAsync(ThemeChangeEventArgs args)
    {
        //TODO: CookieServiceError
        //await _cookieService.SetAsync(CookieName,args.ThemeName);
        _theme = args.ThemeName;
        ThemeChangeEvent?.Invoke(this, args);
        await Task.CompletedTask;
    }

    public event EventHandler<ThemeChangeEventArgs> ThemeChangeEvent;

    public ValueTask<string> GetCookiesThemeAsync()
    {
        return ValueTask.FromResult(_theme);
    }
}