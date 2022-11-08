using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using BlazorComponent;
using SuperCreation.Abp.CodeDocs.Code;
using SuperCreation.Abp.MasaBlazorUI.Components;


namespace SuperCreation.Abp.CodeDocs.Blazor.Pages;

public partial class FunctionParameterManagement
{
    [Inject] public IFunctionParameterAppService FunctionParameterAppService { get; set; }
    [Parameter] public Guid FunctionId { get; set; }
    [Parameter] public List<CodeClassSelectDto> SelectItems { get; set; }
    protected List<DataTableHeader<FunctionParameterDto>> DataTableHeaders { get; set; } = new();
    protected List<FunctionParameterDto> Entities { get; set; } = new();
    protected FunctionParameterCreateUpdateDto EntityCreateDto { get; set; }
    protected FunctionParameterCreateUpdateDto EntityUpdateDto { get; set; }
    protected EntityModal CreateModal { get; set; }
    protected EntityModal UpdateModal { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DataTableHeaders.AddRange(new DataTableHeader<FunctionParameterDto>[]
        {
                new(){Text = L["Name"],Value = nameof(FunctionParameterDto.Name)},
                new(){Text = L["Type"],Value =$"{nameof(FunctionParameterDto.Type)}.{nameof(CodeClassLookupDto.Name)}" , Sortable = false},
                new() { Text =L[ "Actions"], Value = "actions", Sortable = false, Width = "100px", Align = "center" }
        });
        await GetEntitiesAsync();
    }
    protected virtual async Task GetEntitiesAsync()
    {
            Entities = await FunctionParameterAppService.GetAllWithFunctionIdAsync(FunctionId);
            await InvokeAsync(StateHasChanged);
    }
    protected virtual async Task OnCreateClickAsync()
    {
            EntityCreateDto = new() { FunctionId = FunctionId };
            await CreateModal.OpenAsync();
        
    }
    protected virtual async Task OnUpdateClickAsync(FunctionParameterDto item)
    {
        EntityUpdateDto = ObjectMapper.Map<FunctionParameterDto, FunctionParameterCreateUpdateDto>(item);
        await UpdateModal.OpenAsync();
    }
    protected virtual async Task OnDeleteClickAsync(FunctionParameterDto item)
    {
        if (await PopupService.ConfirmAsync(L["Delete"], L["DeleteConfirm"]))
        {
            await FunctionParameterAppService.DeleteAsync(item.FunctionId, item.Name);
            await GetEntitiesAsync();
        }
    }
    protected virtual async Task OnCreateAsync()
    {
        await FunctionParameterAppService.CreateAsync(EntityCreateDto);
        await CreateModal.CloseAsync();
        await GetEntitiesAsync();
    }
    protected virtual async Task OnUpdateAsync()
    {
        await FunctionParameterAppService.UpdateAsync(EntityUpdateDto);
        await UpdateModal.CloseAsync();
        await GetEntitiesAsync();
    }
}
