using MasaDemoApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MasaDemoApp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MasaDemoAppPageModel : AbpPageModel
{
    protected MasaDemoAppPageModel()
    {
        LocalizationResourceType = typeof(MasaDemoAppResource);
        ObjectMapperContext = typeof(MasaDemoAppWebModule);
    }
}
