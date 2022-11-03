using System.Threading.Tasks;

namespace Secyud.Abp.AspNetCore.Components.Web.Theming.Toolbars;

public interface IToolbarManager
{
    Task<Toolbar> GetAsync(string name);
}
