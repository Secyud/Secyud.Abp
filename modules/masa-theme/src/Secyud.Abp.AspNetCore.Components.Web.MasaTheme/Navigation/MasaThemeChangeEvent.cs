using System.Threading.Tasks;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;


public delegate Task MasaThemeChangeEvent(object sender, MasaThemeChangeEventArgs args);

public class MasaThemeChangeEventArgs
{
    public string ThemeName { get; set; }
}