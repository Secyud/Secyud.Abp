using System.Threading.Tasks;
using Volo.Abp.Localization;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;

public interface ILanguagePlatformManager
{
    Task ChangeAsync(LanguageInfo newLanguage);

    Task<LanguageInfo> GetCurrentAsync();
}