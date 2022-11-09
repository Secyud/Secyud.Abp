using Secyud.Abp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Secyud.Abp.CodeDocs.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CodeDocsPageModel : AbpPageModel
{
    protected CodeDocsPageModel()
    {
        LocalizationResourceType = typeof(CodeDocsResource);
        ObjectMapperContext = typeof(CodeDocsWebModule);
    }
}