using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.Components.FeatureManagement;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.Localization;
using Volo.Abp.Features;

namespace Secyud.Abp.Components.SettingGroup;

public partial class FeatureSettingManagementComponent 
{
    [Inject]
    protected PermissionChecker PermissionChecker { get; set; }
    
    protected FeatureManagementModal ManagementModal;
    
    protected FeatureSettingViewModel Settings;

    public FeatureSettingManagementComponent()
    {
        LocalizationResource = typeof(AbpFeatureManagementResource);
    }

    protected async override Task OnInitializedAsync()
    {
        Settings = new FeatureSettingViewModel 
        {
            HasManageHostFeaturesPermission = await PermissionChecker.IsGrantedAsync(FeatureManagementPermissions.ManageHostFeatures)
        };
    }

    protected virtual async Task OnManageHostFeaturesClicked()
    {
       await ManagementModal.OpenAsync(TenantFeatureValueProvider.ProviderName);
    }
}