using System.Threading.Tasks;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming.Toolbars;

public interface IToolbarContributor
{
    Task ConfigureToolbarAsync(IToolbarConfigurationContext context);
}
