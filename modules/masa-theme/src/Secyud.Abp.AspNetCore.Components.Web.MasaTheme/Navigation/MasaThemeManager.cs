using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;

public class MasaThemeManager:IScopedDependency
{
    public event MasaThemeChangeEvent ThemeChangeEvent;
    
    public async Task ChangeThemeAsync(MasaThemeChangeEventArgs args)
    {
        if (ThemeChangeEvent is not null)
        {
            await ThemeChangeEvent.Invoke(this,args);
        }
    }
}
