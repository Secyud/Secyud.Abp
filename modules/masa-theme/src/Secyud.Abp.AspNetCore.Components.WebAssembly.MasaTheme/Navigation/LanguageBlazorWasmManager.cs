using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;

namespace Secyud.Abp.AspNetCore.Components.WebAssembly.MasaTheme.Navigation
{
    [ExposeServices(typeof(ILanguagePlatformManager))]
    public class MasaLanguageBlazorWasmManager : ILanguagePlatformManager, ITransientDependency
    {
        protected IJSRuntime JsRuntime { get; }

        protected ILanguageProvider LanguageProvider { get; }

        public MasaLanguageBlazorWasmManager(
            IJSRuntime jsRuntime,
            ILanguageProvider languageProvider)
        {
            JsRuntime = jsRuntime;
            LanguageProvider = languageProvider;
        }

        public async Task ChangeAsync(LanguageInfo newLanguage)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(newLanguage.UiCultureName);

            await JsRuntime.InvokeVoidAsync(
                "localStorage.setItem",
                "Abp.SelectedLanguage", newLanguage.UiCultureName
            );

            await JsRuntime.InvokeVoidAsync(
                "localStorage.setItem",
                "Abp.IsRtl", CultureHelper.IsRtl
            );

            await JsRuntime.InvokeVoidAsync("location.reload");
        }

        public async Task<LanguageInfo> GetCurrentAsync()
        {
            var selectedLanguageName = await JsRuntime.InvokeAsync<string>(
                "localStorage.getItem",
                "Abp.SelectedLanguage"
            );

            var languages = await LanguageProvider.GetLanguagesAsync();

            var currentLanguage = languages.FirstOrDefault(l => l.UiCultureName == selectedLanguageName) ??
                                  languages.FirstOrDefault(l => l.UiCultureName == CultureInfo.CurrentUICulture.Name) ??
                                  languages.FirstOrDefault();

            return currentLanguage;
        }
    }
}