using System.Threading.Tasks;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;

public interface IThemeManager
{
    Task ChangeThemeAsync(ThemeChangeEventArgs args);
}