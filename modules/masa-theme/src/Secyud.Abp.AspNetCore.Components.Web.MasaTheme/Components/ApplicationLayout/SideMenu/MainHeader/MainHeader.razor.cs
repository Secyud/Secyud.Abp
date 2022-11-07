using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Secyud.Abp.MasaTheme.Shared.Localization;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.SideMenu.MainHeader
{
    public partial class MainHeader 
    {
        [Inject] protected MainMenuProvider MainMenuProvider { get; set; }
        
        [Parameter] public EventCallback OnToggle { get; set; }
        
        protected MenuViewModel Menu { get; set; }

        [CascadingParameter(Name = "IsDark")] public bool CascadingIsDark { get; set; }

        private const string DarkThemeBackGround = "https://loremflickr.com/cache/resized/65535_52469866505_5ff2e5ecdb_h_1280_720_nofilter.jpg?hmac=RWVZ2Q-1iRuxO0BgbTo-iZVfj7YbT17Dd3BS11rqAVQ";
        private const string LightThemeBackGround = "https://i.picsum.photos/id/732/1920/1080.jpg?hmac=RWVZ2Q-1iRuxO0BgbTo-iZVfj7YbT17Dd3BS11rqAVQ";
        
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
