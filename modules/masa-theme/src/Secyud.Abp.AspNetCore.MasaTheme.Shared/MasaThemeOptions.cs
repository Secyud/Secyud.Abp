using System.Collections.Generic;
using System.Linq;

namespace Secyud.Abp.MasaTheme.Shared;

public class MasaThemeOptions
{
    public Dictionary<string, MasaThemeStyle> Styles { get; } = new();

    /// <summary>
    /// Defines the default fallback theme. Default value is <see cref="MasaStyleNames.System"/>
    /// </summary>
    public string DefaultStyle { get; set; } = MasaStyleNames.Light;

    public MasaThemeStyle GetDefaultStyle()
    {
        if (string.IsNullOrEmpty(DefaultStyle) || !Styles.ContainsKey(DefaultStyle))
        {
            return Styles.FirstOrDefault().Value;
        }

        return Styles[DefaultStyle];
    }
}
