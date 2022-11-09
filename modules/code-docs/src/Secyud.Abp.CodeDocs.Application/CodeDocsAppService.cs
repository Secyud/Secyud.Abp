using Secyud.Abp.Localization;
using Volo.Abp.Application.Services;

namespace Secyud.Abp;

public abstract class CodeDocsAppService : ApplicationService
{
    protected CodeDocsAppService()
    {
        LocalizationResource = typeof(CodeDocsResource);
        ObjectMapperContext = typeof(CodeDocsApplicationModule);
    }
}