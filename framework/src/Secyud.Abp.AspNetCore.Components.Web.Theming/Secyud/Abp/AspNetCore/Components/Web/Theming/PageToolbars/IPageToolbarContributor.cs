using System.Threading.Tasks;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming.PageToolbars;

public interface IPageToolbarContributor
{
    Task ContributeAsync(PageToolbarContributionContext context);
}