namespace Secyud.Abp.AspNetCore.Components.Web.Theming.PageToolbars;

public class PageToolbar
{
    public PageToolbar()
    {
        Contributors = new PageToolbarContributorList();
    }

    public PageToolbarContributorList Contributors { get; set; }
}