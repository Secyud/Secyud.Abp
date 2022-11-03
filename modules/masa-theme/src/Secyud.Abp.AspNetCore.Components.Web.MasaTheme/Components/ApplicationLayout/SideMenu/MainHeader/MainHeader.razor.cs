using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Secyud.Abp.MasaTheme.Shared.Localization;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.SideMenu.MainHeader
{
    public partial class MainHeader 
    {
        [Inject]
        protected MainMenuProvider MainMenuProvider { get; set; }

        protected MenuViewModel Menu { get; set; }

        public MainHeader()
        {
            LocalizationResource = typeof(MasaResource);
        }
        
        protected override async Task OnInitializedAsync()
        {
            Menu = await MainMenuProvider.GetMenuAsync();
            Menu.StateChanged += RefreshMenu;
        }

        public void Dispose()
        {
            Menu.StateChanged -= RefreshMenu;
        }

        private void RefreshMenu(object sender, EventArgs e)
        {
            InvokeAsync(StateHasChanged);
        }
    }
}
