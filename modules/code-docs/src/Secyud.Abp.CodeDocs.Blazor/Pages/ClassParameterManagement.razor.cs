using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorComponent;
using SuperCreation.Abp.CodeDocs.Code;
using SuperCreation.Abp.MasaBlazorUI.Components;


namespace SuperCreation.Abp.CodeDocs.Blazor.Pages
{
    public partial class ClassParameterManagement
    {
        [Inject] public IClassParameterAppService ClassParameterAppService { get; set; }
        [Parameter] public Guid ClassId { get; set; }
        [Parameter] public List<CodeClassSelectDto> SelectItems { get; set; }
        protected List<DataTableHeader<ClassParameterDto>> DataTableHeaders { get; set; } = new();
        protected List<ClassParameterDto> Entities { get; set; } = new();
        protected ClassParameterCreateUpdateDto EntityCreateDto { get; set; }
        protected ClassParameterCreateUpdateDto EntityUpdateDto { get; set; }
        protected EntityModal CreateModal { get; set; }
        protected EntityModal UpdateModal { get; set; }

        protected override async Task OnInitializedAsync()
        {
            DataTableHeaders.AddRange(new DataTableHeader<ClassParameterDto>[]
            {
                new(){Text = L["Name"],Value = nameof(ClassParameterDto.Name)},
                new(){Text = L["Type"],Value =$"{nameof(ClassParameterDto.Type)}.{nameof(CodeClassLookupDto.Name)}", Sortable = false },
                new(){Text = L["IsPublic"],Value = nameof(ClassParameterDto.IsPublic) },
                new() { Text =L[ "Actions"], Value = "actions", Sortable = false, Width = "100px", Align = "center" }
            });
            await GetEntitiesAsync();
        }

        protected virtual async Task GetEntitiesAsync()
        {
                Entities = await ClassParameterAppService.GetAllWithClassIdAsync(ClassId);
                await InvokeAsync(StateHasChanged);
        }


        protected virtual async Task OnCreateClickAsync()
        {
                EntityCreateDto = new() { ClassId = ClassId };
                await CreateModal.OpenAsync();
        }
    
        protected virtual async Task OnUpdateClickAsync(ClassParameterDto item)
        {
            EntityUpdateDto = ObjectMapper.Map<ClassParameterDto, ClassParameterCreateUpdateDto>(item);
            await UpdateModal.OpenAsync();
        }

        protected virtual async Task OnDeleteClickAsync(ClassParameterDto item)
        {
            if (await PopupService.ConfirmAsync(L["Delete"], L["DeleteConfirm"]))
            {
                await ClassParameterAppService.DeleteAsync(item.ClassId, item.Name);
                await GetEntitiesAsync();
            }
        }

        protected virtual async Task OnCreateAsync()
        {
            await ClassParameterAppService.CreateAsync(EntityCreateDto);
            await CreateModal.CloseAsync();
            await GetEntitiesAsync();
        }

        protected virtual async Task OnUpdateAsync()
        {
            await ClassParameterAppService.UpdateAsync(EntityUpdateDto);
            await UpdateModal.CloseAsync();
            await GetEntitiesAsync();
        }
    }
}
