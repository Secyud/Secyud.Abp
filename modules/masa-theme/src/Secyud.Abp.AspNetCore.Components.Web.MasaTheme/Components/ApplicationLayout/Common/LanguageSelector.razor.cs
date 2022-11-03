using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Volo.Abp.Localization;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.Common;

public partial class LanguageSelector
{
    [Inject] public ILanguagePlatformManager LanguagePlatformManager { get; private set; }

    [Inject] public ILanguageProvider LanguageProvider { get; private set; }

    public IReadOnlyList<LanguageInfo> Languages { get; private set; }

    public LanguageInfo CurrentLanguage { get; private set; }

    public string CurrentLanguageTwoLetters { get; private set; }

    public bool HasLanguages { get; private set; }


    protected override async Task OnInitializedAsync()
    {
        Languages = await LanguageProvider.GetLanguagesAsync();
        CurrentLanguage = await LanguagePlatformManager.GetCurrentAsync();

        if (CurrentLanguage != null && !CurrentLanguage.CultureName.IsNullOrWhiteSpace())
        {
            CurrentLanguageTwoLetters = new CultureInfo(CurrentLanguage.CultureName).TwoLetterISOLanguageName.ToUpperInvariant();
        }

        HasLanguages = Languages.Any() || CurrentLanguage == null;
    }
}
