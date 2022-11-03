using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Layout;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Themes.Masa.Components.Common.ContentTitle;

public class ContentTitleViewComponent : AbpViewComponent
{
    protected IPageLayout PageLayout { get; }

    public ContentTitleViewComponent(IPageLayout pageLayout)
    {
        PageLayout = pageLayout;
    }

    public virtual IViewComponentResult Invoke()
    {
        return View(
             "~/Themes/Masa/Components/Common/ContentTitle/Default.cshtml",
             PageLayout.Content);
    }
}
