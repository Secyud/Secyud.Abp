using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Layout;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Themes.Masa.Components.Common.BreadCrumb;

public class ContentBreadCrumbViewComponent : MasaViewComponentBase
{
    protected IPageLayout PageLayout { get; }

    public ContentBreadCrumbViewComponent(IPageLayout pageLayout)
    {
        PageLayout = pageLayout;
    }

    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Masa/Components/Common/BreadCrumb/Default.cshtml", PageLayout.Content);
    }
}
