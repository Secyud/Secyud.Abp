using Secyud.Abp.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Secyud.Abp.Pages;

public class CodeDocsComponentBase : AbpComponentBase
{
    public CodeDocsComponentBase()
    {
        LocalizationResource = typeof(CodeDocsResource);
    }
}