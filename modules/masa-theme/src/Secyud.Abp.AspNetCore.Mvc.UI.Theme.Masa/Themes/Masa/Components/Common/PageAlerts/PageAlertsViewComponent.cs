using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;

namespace Secyud.Abp.AspNetCore.Mvc.UI.Theme.Masa.Themes.Masa.Components.Common.PageAlerts;
public class PageAlertsViewComponent : MasaViewComponentBase
{
    protected IAlertManager AlertManager { get; }

    public PageAlertsViewComponent(IAlertManager alertManager)
    {
        AlertManager = alertManager;
    }

    public virtual IViewComponentResult Invoke()
    {
        return View("~/Themes/Masa/Components/Common/PageAlerts/Default.cshtml", AlertManager.Alerts);
    }
}
