using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp;

namespace Secyud.Abp.Pages.CodeDocsManagement;

public partial class CodeClassBrowseDetailsPage
{
    protected List<NameValue<Guid>> CodeClassNameValueList;
    protected CodeClassDto CodeClassParent;

    protected CodeClassDto CodeClassWithDetails;
    protected List<CodeFunctionDto> CodeFunctionsWithDetails;
    [Inject] protected ICodeClassAppService AppService { get; set; }
    [Inject] protected ICodeFunctionAppService CodeFunctionAppService { get; set; }

    [Parameter] public Guid CodeClassId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CodeClassNameValueList = await AppService.GetNameValueListAsync(new GetCodeClassListInput
        {
            MaxResultCount = int.MaxValue
        });

        CodeClassWithDetails = await AppService.GetAsync(CodeClassId);

        if (CodeClassWithDetails is not null && CodeClassWithDetails.ParentId != default)
            CodeClassParent = await AppService.GetAsync(CodeClassWithDetails.ParentId);

        CodeFunctionsWithDetails = await CodeFunctionAppService.GetListWithDetailsAsync(new GetCodeFunctionListInput
        {
            MaxResultCount = int.MaxValue,
            ClassId = CodeClassId
        });
    }

    protected string NavUrl(Guid codeClassId)
    {
        return $"code-docs/browse/{codeClassId}";
    }
}