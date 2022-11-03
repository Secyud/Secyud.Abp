using JetBrains.Annotations;
using Volo.Abp.Localization;

namespace Secyud.Abp.MasaTheme.Shared;

public class MasaThemeStyle
{
    public LocalizableString DisplayName { get; set; }

    [CanBeNull]
    public string Icon { get; set; }

    public MasaThemeStyle(LocalizableString displayName, [CanBeNull] string icon = null)
    {
        DisplayName = displayName;
        Icon = icon;
    }
}
