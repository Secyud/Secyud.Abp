using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Secyud.Abp.MasaTheme.Shared.Localization;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.SideMenu.MainHeader;

public partial class MainHeader
{
    private const string DarkThemeBackGround = "https://picsum.photos/1920/1080?random=2&blur=1";
    private const string LightThemeBackGround = "https://picsum.photos/1920/1080?random=1&blur=1";

    public MainHeader()
    {
        LocalizationResource = typeof(MasaResource);
    }

    [Inject] protected MainMenuProvider MainMenuProvider { get; set; }

    [Parameter] public EventCallback OnToggle { get; set; }

    protected MenuViewModel Menu { get; set; }

    [CascadingParameter(Name = "IsDark")] public bool CascadingIsDark { get; set; }

    public void Dispose()
    {
        Menu.StateChanged -= RefreshMenu;
    }

    protected override async Task OnInitializedAsync()
    {
        Menu = await MainMenuProvider.GetMenuAsync();
        Menu.StateChanged += RefreshMenu;
    }

    private void RefreshMenu(object sender, EventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
}