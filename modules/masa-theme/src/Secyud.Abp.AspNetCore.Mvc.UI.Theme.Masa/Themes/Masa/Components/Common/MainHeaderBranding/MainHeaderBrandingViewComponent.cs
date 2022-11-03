using Microsoft.AspNetCore.Mvc;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Themes.Masa.Components.Common.MainHeaderBranding;
public class MainHeaderBrandingViewComponent : MasaViewComponentBase
{
    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Masa/Components/Common/MainHeaderBranding/Default.cshtml");
    }
}
