using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.RequestLocalization;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;

namespace Secyud.Abp.AspNetCore.Components.Server.MasaTheme.Navigation
{
    [ExposeServices(typeof(ILanguagePlatformManager))]
    public class MasaLanguageBlazorServerManager : ILanguagePlatformManager, ITransientDependency
    {
        protected NavigationManager NavigationManager { get; }

        protected ILanguageProvider LanguageProvider { get; }

        protected IAbpRequestLocalizationOptionsProvider RequestLocalizationOptionsProvider { get; }

        public MasaLanguageBlazorServerManager(
            NavigationManager navigationManager,
            ILanguageProvider languageProvider,
            IAbpRequestLocalizationOptionsProvider requestLocalizationOptionsProvider)
        {
            NavigationManager = navigationManager;
            LanguageProvider = languageProvider;
            RequestLocalizationOptionsProvider = requestLocalizationOptionsProvider;
        }

        public Task ChangeAsync(LanguageInfo newLanguage)
        {
            var relativeUrl = NavigationManager.Uri.RemovePreFix(NavigationManager.BaseUri).EnsureStartsWith('/');

            NavigationManager.NavigateTo(
                $"/Abp/Languages/Switch?culture={newLanguage.CultureName}&uiCulture={newLanguage.UiCultureName}&returnUrl={relativeUrl}",
                forceLoad: true
            );

            return Task.CompletedTask;
        }

        public async Task<LanguageInfo> GetCurrentAsync()
        {
            var languages = await LanguageProvider.GetLanguagesAsync();
            var currentLanguage = languages.FindByCulture(
                CultureInfo.CurrentCulture.Name,
                CultureInfo.CurrentUICulture.Name
            );

            if (currentLanguage == null)
            {
                var localizationOptions = await RequestLocalizationOptionsProvider.GetLocalizationOptionsAsync();
                currentLanguage = new LanguageInfo(
                    localizationOptions.DefaultRequestCulture.Culture.Name,
                    localizationOptions.DefaultRequestCulture.UICulture.Name,
                    localizationOptions.DefaultRequestCulture.UICulture.DisplayName);
            }

            return currentLanguage;
        }
    }
}
