using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Secyud.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.AspNetCore.Components.Web;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.SideMenu.MainHeader
{
    public partial class MainHeaderToolbar
    {
        [Inject] private IToolbarManager ToolbarManager { get; set; }

        private List<RenderFragment> ToolbarItemRenders { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            var toolbar = await ToolbarManager.GetAsync(StandardToolbars.Main);

            foreach (var item in toolbar.Items)
            {
                ToolbarItemRenders.Add(builder =>
                {
                    builder.OpenComponent(0, item.ComponentType);
                    builder.CloseComponent();
                });
            }
        }
    }
}
