using Volo.Abp.AspNetCore.Components;
using Volo.Abp.FeatureManagement.Localization;

namespace Secyud.Abp;

public abstract class AbpFeatureManagementComponentBase : AbpComponentBase
{
    protected AbpFeatureManagementComponentBase()
    {
        LocalizationResource = typeof(AbpFeatureManagementResource);
    }
}
