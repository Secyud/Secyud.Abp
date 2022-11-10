using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorComponent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Secyud.Abp.SettingManagement;
using Volo.Abp.Features;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Localization;

namespace Secyud.Abp.Pages.SettingManagement;

[Authorize]
[RequiresFeature(SettingManagementFeatures.Enable)]
public partial class SettingManagement
{
    protected readonly List<BreadcrumbItem> BreadcrumbItems = new();

    protected StringNumber SelectedGroup;
    [Inject] protected IServiceProvider ServiceProvider { get; set; }

    protected SettingComponentCreationContext SettingComponentCreationContext { get; set; }

    [Inject] protected IOptions<SettingManagementComponentOptions> OptionsContainer { get; set; }

    [Inject] protected IStringLocalizer<AbpSettingManagementResource> L { get; set; }

    protected SettingManagementComponentOptions Options => OptionsContainer.Value;

    protected override async Task OnInitializedAsync()
    {
        BreadcrumbItems.Add(new BreadcrumbItem { Text = L["Settings"] });

        SettingComponentCreationContext = new SettingComponentCreationContext(ServiceProvider);

        foreach (var contributor in Options.Contributors)
        {
            await contributor.ConfigureAsync(SettingComponentCreationContext);
        }

        SelectedGroup = GetNormalizedString(SettingComponentCreationContext.Groups.First().Id);
    }

    protected virtual string GetNormalizedString(string value)
    {
        return value.Replace('.', '_');
    }
}