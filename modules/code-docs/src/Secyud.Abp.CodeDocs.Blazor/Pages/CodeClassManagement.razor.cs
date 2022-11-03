using BlazorComponent;
using Microsoft.AspNetCore.Components;
using SuperCreation.Abp.CodeDocs.Code;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using SuperCreation.Abp.MasaBlazorUI.Components;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Blazor.Pages;

public partial class CodeClassManagement
{
    [Inject] public ICodeClassAppService CodeClassAppService { get; set; }

    protected List<DataTableHeader<CodeClassLookupDto>> DataTableHeaders = new();
    protected List<BreadcrumbItem> BreadcrumbItems = new();
    protected List<CodeClassLookupDto> Entities { get; set; } = new();
    protected List<CodeClassSelectDto> SelectItems { get; set; } = new();
    protected int ServerItemsLength { get; set; }
    protected CodeClassGetListDto EntityGetListDto { get; set; } = new()
    {
        Filter = null,
        MaxResultCount = 15,
        SkipCount = 0,
        Sorting = ""
    };

    protected CodeClassCreateUpdateDto EntityCreateDto { get; set; }
    protected CodeClassCreateUpdateDto EntityUpdateDto { get; set; }
    protected EntityModal CreateModal { get; set; }
    protected EntityModal UpdateModal { get; set; }

    protected CodeClassLookupDto Detail { get; set; }

    protected bool Loading { get; set; }

    protected bool Drawer
    {
        get => Detail is not null;
        set
        {
            if (!value)
                Detail = null;
        }
    }
    protected override async Task OnInitializedAsync()
    {
        BreadcrumbItems.AddRange(new BreadcrumbItem[]
        {
            new() { Text = L["CodeDocs"] },
            new() { Text = L["CodeDocsManagement"]  }
        });

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

    protected virtual async Task GetEntitiesAsync()
    {
        IPagedResult<CodeClassLookupDto> entityPage = await CodeClassAppService.GetListAsync(EntityGetListDto);
        Entities = entityPage.Items.ToList();
        ServerItemsLength = (int)(entityPage.TotalCount);
        SelectItems = await CodeClassAppService.GetSelectListAsync();
        Loading = false;
        await InvokeAsync(StateHasChanged);
    }

    protected virtual async Task OnCreateClickAsync()
    {
        EntityCreateDto = new();
        await CreateModal.OpenAsync();
    }
    protected virtual async Task OnUpdateClickAsync(CodeClassLookupDto item)
    {
        var dto = await CodeClassAppService.GetAsync(item.Id);
        EntityUpdateDto = ObjectMapper.Map<CodeClassDto, CodeClassCreateUpdateDto>(dto);
        await UpdateModal.OpenAsync();
    }
    protected virtual async Task OnDetailClickAsync(CodeClassLookupDto item)
    {
        Detail = item;
        await InvokeAsync(StateHasChanged);
    }

    protected virtual async Task OnCancelDetailClickAsync(CodeClassLookupDto item)
    {
        Detail = null;
        await InvokeAsync(StateHasChanged);
    }

    protected virtual async Task OnDeleteClickAsync(CodeClassLookupDto item)
    {
        if (await PopupService.ConfirmAsync(L["Delete"], L["DeleteConfirm"]))
        {
            await CodeClassAppService.DeleteAsync(item.Id);
            await GetEntitiesAsync();
            await InvokeAsync(StateHasChanged);
        }
    }

    protected virtual async Task OnCreateAsync()
    {
        await CodeClassAppService.CreateAsync(EntityCreateDto);
        await CreateModal.CloseAsync();
        await GetEntitiesAsync();
        await InvokeAsync(StateHasChanged);
    }

    protected virtual async Task OnUpdateAsync()
    {
        await CodeClassAppService.UpdateAsync(EntityUpdateDto);
        await UpdateModal.CloseAsync();
        await GetEntitiesAsync();
        await InvokeAsync(StateHasChanged);
    }

    protected virtual async Task OnOptionsUpdate(DataOptions dataOptions)
    {
        List<string> sortStr = new();
        
        for (int i = 0; i < dataOptions.SortBy.Count; i++)
        {
            sortStr.Add(dataOptions.SortDesc[i] ? dataOptions.SortBy[i] + " DESC" : dataOptions.SortBy[i]);
        }
        EntityGetListDto.Sorting = sortStr.JoinAsString(",");

        EntityGetListDto.SkipCount = (dataOptions.Page - 1) * dataOptions.ItemsPerPage;

        EntityGetListDto.MaxResultCount = dataOptions.ItemsPerPage;

        await GetEntitiesAsync();
    }

    protected virtual async Task OnSearchEnter(KeyboardEventArgs  e)
    {
        if (e.Code == "Enter"||e.Code== "NumpadEnter") await GetEntitiesAsync();
    }
}
