using Secyud.Abp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Secyud.Abp;

public abstract class CodeDocsController : AbpControllerBase
{
    protected CodeDocsController()
    {
        LocalizationResource = typeof(CodeDocsResource);
    }
}
