using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Navigation;
using Volo.Abp.MultiTenancy;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace Secyud.Abp.AspNetCore.Components.Web.MasaTheme.Components.ApplicationLayout.SideMenu.Navigation
{
    public partial class MainMenu 
    {
        [Inject] protected MainMenuProvider MainMenuProvider { get; set; }

        [Inject] protected IMenuManager MenuManager { get; set; }
        
        [Inject] protected ICurrentUser CurrentUser { get; set; }
        
        [Inject] protected ICurrentTenant CurrentTenant { get; set; }

        [Parameter] public EventCallback OnClickCallback { get; set; }

        private bool _mini;
        
        protected MenuViewModel Menu { get; set; }
        
        protected Guid? UserId { get; set; }

        protected string UserName { get; set; }

        protected string TenantName { get; set; }

        protected string ProfileImageUrl { get; set; }

        protected string UserFullName { get; set; }

        protected string UserEmail { get; set; }
        
        protected ApplicationMenu UserMenu { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UserMenu = await MenuManager.GetAsync(StandardMenus.User);
             
            UserId = CurrentUser.Id;
            UserName = CurrentUser.UserName;
            UserFullName = CalculateUserFullName();
            TenantName = CurrentTenant.Name;
            UserEmail = CurrentUser.Email;
             
            if (UserId != null)
            {
                ProfileImageUrl = $"/api/account/profile-picture-file/{UserId}";
            }
            
            Menu = await MainMenuProvider.GetMenuAsync();
            Menu.StateChanged += Menu_StateChanged;
        }

        private void Menu_StateChanged(object sender, EventArgs e)
        {
            InvokeAsync(StateHasChanged);
        }
        
        protected virtual string CalculateUserFullName()
        {
            return CurrentUser.Name.IsNullOrEmpty() || CurrentUser.SurName.IsNullOrEmpty() ?
                CurrentUser.UserName : 
                $"{CurrentUser.Name} {CurrentUser.SurName}";
        }

        public void Dispose()
        {
            Menu.StateChanged -= Menu_StateChanged;
        }
    }
}
