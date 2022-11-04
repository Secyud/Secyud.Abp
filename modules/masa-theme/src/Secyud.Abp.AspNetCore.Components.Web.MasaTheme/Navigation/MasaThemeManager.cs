using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Notifications;
using Volo.Abp.DependencyInjection;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;

[Dependency(ReplaceServices = true)]
public class MasaThemeManager:IThemeManager,IScopedDependency
{
    public event EventHandler<ThemeChangeEventArgs> ThemeChangeEvent;
    
    public Task ChangeThemeAsync(ThemeChangeEventArgs args)
    {
        ThemeChangeEvent?.Invoke(this,args);
        return Task.CompletedTask;
    }
}
