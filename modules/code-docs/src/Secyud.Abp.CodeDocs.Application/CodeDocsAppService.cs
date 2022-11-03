using SuperCreation.Abp.CodeDocs.Localization;
using Volo.Abp.Application.Services;

namespace SuperCreation.Abp.CodeDocs;

public abstract class CodeDocsAppService : ApplicationService
{
    protected CodeDocsAppService()
    {
        LocalizationResource = typeof(CodeDocsResource);
        ObjectMapperContext = typeof(CodeDocsApplicationModule);
    }
}
