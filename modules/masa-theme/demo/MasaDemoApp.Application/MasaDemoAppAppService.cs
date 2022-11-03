using MasaDemoApp.Localization;
using Volo.Abp.Application.Services;

namespace MasaDemoApp;

public abstract class MasaDemoAppAppService : ApplicationService
{
    protected MasaDemoAppAppService()
    {
        LocalizationResource = typeof(MasaDemoAppResource);
        ObjectMapperContext = typeof(MasaDemoAppApplicationModule);
    }
}
