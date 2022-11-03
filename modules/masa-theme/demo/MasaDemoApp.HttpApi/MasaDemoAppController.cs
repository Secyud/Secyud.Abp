using MasaDemoApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MasaDemoApp;

public abstract class MasaDemoAppController : AbpControllerBase
{
    protected MasaDemoAppController()
    {
        LocalizationResource = typeof(MasaDemoAppResource);
    }
}
