using BlazorComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SuperCreation.Abp.CodeDocs.Code;
using SuperCreation.Abp.MasaBlazorUI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SuperCreation.Abp.CodeDocs.Blazor.Pages
{
    public partial class CodeFunctionManagement
    {
        [Inject] public ICodeFunctionAppService CodeFunctionAppService { get; set; }

        [Parameter] public Guid ClassId { get; set; }
        [Parameter] public List<CodeClassSelectDto> SelectItems { get; set; }

        protected List<DataTableHeader<CodeFunctionDto>> DataTableHeaders = new();
        protected List<CodeFunctionDto> Entities { get; set; } = new();
        protected CodeFunctionCreateUpdateDto EntityCreateDto { get; set; }
        protected CodeFunctionCreateUpdateDto EntityUpdateDto { get; set; }
        protected EntityModal CreateModal { get; set; }
        protected EntityModal UpdateModal { get; set; }

        protected CodeFunctionDto Detail { get; set; }
        
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
            DataTableHeaders.AddRange(new DataTableHeader<CodeFunctionDto>[]
            {
                new() { Text = L["Name"], Sortable = true, Value = nameof(CodeFunctionDto.Name), Filterable = true },
                new()
                {
                    Text = L["Return"], Value = $"{nameof(CodeFunctionDto.Return)}.{nameof(CodeClassLookupDto.Name)}",
                    Sortable = false
                },
                new() { Text = L["IsStatic"], Value = nameof(CodeFunctionDto.IsStatic) },
                new() { Text = L["IsVirtual"], Value = nameof(CodeFunctionDto.IsVirtual) },
                new() { Text = "Actions", Value = "actions", Sortable = false, Width = "100px", Align = "center" }
            });
            await GetEntitiesAsync();
        }

        protected virtual async Task GetEntitiesAsync()
        {
                Entities = await CodeFunctionAppService.GetAllWithClassIdAsync(ClassId);
                await InvokeAsync(StateHasChanged);
        }

        protected virtual async Task OnCreateClickAsync()
        {
                EntityCreateDto = new() { ClassId = ClassId };
                await CreateModal.OpenAsync();
        }
        protected virtual async Task OnUpdateClickAsync(CodeFunctionDto item)
        {
            EntityUpdateDto = ObjectMapper.Map<CodeFunctionDto, CodeFunctionCreateUpdateDto>(item);
            await UpdateModal.OpenAsync();
        }
        protected virtual async Task OnDetailClickAsync(CodeFunctionDto item)
        {
            Detail = item;
            await InvokeAsync(StateHasChanged);
        }
        protected virtual async Task OnCancelDetailClickAsync()
        {
            Detail = null;
            await InvokeAsync(StateHasChanged);
        }

        protected virtual async Task OnDeleteClickAsync(CodeFunctionDto item)
        {
            if (await PopupService.ConfirmAsync(L["Delete"], L["DeleteConfirm"]))
            {
                await CodeFunctionAppService.DeleteAsync(item.Id);
                await GetEntitiesAsync();
            }
        }
        protected virtual async Task OnCreateAsync()
        {
            await CodeFunctionAppService.CreateAsync(EntityCreateDto);
            await CreateModal.CloseAsync();
            await GetEntitiesAsync();
        }

        protected virtual async Task OnUpdateAsync()
        {
            await CodeFunctionAppService.UpdateAsync(EntityUpdateDto);
            await UpdateModal.CloseAsync();
            await GetEntitiesAsync();
        }
    }
}
