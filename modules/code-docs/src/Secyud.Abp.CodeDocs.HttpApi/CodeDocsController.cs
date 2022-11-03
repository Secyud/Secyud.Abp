using SuperCreation.Abp.CodeDocs.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SuperCreation.Abp.CodeDocs;

public abstract class CodeDocsController : AbpControllerBase
{
    protected CodeDocsController()
    {
        LocalizationResource = typeof(CodeDocsResource);
    }
}
