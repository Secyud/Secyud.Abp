using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Secyud.Abp.Components.SettingGroup;
using Secyud.Abp.SettingManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.Localization;

namespace Secyud.Abp.Settings;

public class FeatureSettingManagementComponentContributor : ISettingComponentContributor
{
    public virtual async Task ConfigureAsync(SettingComponentCreationContext context)
    {
        if (!await CheckPermissionsInternalAsync(context)) return;

        var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<AbpFeatureManagementResource>>();
        context.Groups.Add(
            new SettingComponentGroup(
                "Volo.Abp.Feature",
                l["Permission:FeatureManagement"],
                typeof(FeatureSettingManagementComponent)
            )
        );
    }

    public virtual async Task<bool> CheckPermissionsAsync(SettingComponentCreationContext context)
    {
        return await CheckPermissionsInternalAsync(context);
    }

    protected virtual async Task<bool> CheckPermissionsInternalAsync(SettingComponentCreationContext context)
    {
        var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();

        return await authorizationService.IsGrantedAsync(FeatureManagementPermissions.ManageHostFeatures);
    }
}