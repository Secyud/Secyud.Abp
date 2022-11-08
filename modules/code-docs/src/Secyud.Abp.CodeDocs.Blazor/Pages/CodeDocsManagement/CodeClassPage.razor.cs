using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorComponent;
using Masa.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Secyud.Abp.CodeDocsManagement;
using Secyud.Abp.Localization;
using Secyud.Abp.MasaBlazorUi.Components;
using Secyud.Abp.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;

namespace Secyud.Abp.Pages.CodeDocsManagement;

public partial class CodeClassPage
{
    protected List<DataTableHeader<CodeClassDto>> CodeClassHeaders =>TableHeaders.Get<CodeClassPage>();
    protected List<EntityAction> CodeClassEntityActions => EntityActions.Get<CodeClassPage>();
  
    public CodeClassPage()
    {
        LocalizationResource = typeof(CodeDocsResource);

        CreatePolicyName = CodeDocsPermissions.CodeClass.Create;
        UpdatePolicyName = CodeDocsPermissions.CodeClass.Update;
        DeletePolicyName = CodeDocsPermissions.CodeClass.Delete;
    }
    
    protected override async Task OnInitializedAsync()
    {
        
        DataTableHeaders.AddRange(new DataTableHeader<CodeClassLookupDto>[]
        {
            new() { Text = L["Name"], Sortable = true, Value = nameof(CodeClassLookupDto.Name), Filterable = true },
            new() { Text = L["ParentClass"], Sortable = false, Value = nameof(CodeClassLookupDto.ParentName) },
            new() { Text = L["IsVisible"], Value = nameof(CodeClassLookupDto.IsVisible) },
            new() { Text = "Actions", Value = "actions", Sortable = false, Width = "100px", Align = "center" }
        });
        Loading = true;
        await GetEntitiesAsync();
    }

    protected override ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.AddRange(new BreadcrumbItem[]
        {
            new() { Text = L["CodeDocs"] },
            new() { Text = L["CodeDocsManagement"]  }
        });

        return base.SetBreadcrumbItemsAsync();
    }

    protected override ValueTask SetTableHeadersAsync()
    {
        CodeClassHeaders.AddRange(new DataTableHeader<CodeClassDto>[]
        {
            new() { Text = L["Name"], Sortable = true, Value = nameof(CodeClassDto.Name), Filterable = true },
            new() { Text = L["ParentId"], Sortable = false, Value = nameof(CodeClassDto.ParentId) },
            new() { Text = L["IsVisible"], Value = nameof(CodeClassDto.IsVisible) },
            new() { Text = "Actions", Value = "actions", Sortable = false, Width = "100px", Align = "center" }
        });
        
        return base.SetTableHeadersAsync();
    }

    protected virtual async Task OnSearchEnter(KeyboardEventArgs  e)
    {
        if (e.Code is "Enter" or "NumpadEnter") await GetEntitiesAsync();
    }
}
