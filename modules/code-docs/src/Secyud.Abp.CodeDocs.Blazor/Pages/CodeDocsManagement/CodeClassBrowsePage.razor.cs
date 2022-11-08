using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp;

namespace Secyud.Abp.Pages.CodeDocsManagement;

public partial class CodeClassBrowsePage
{
    [Inject] public ICodeClassAppService AppService { get; set; }

    protected ImmutableSortedDictionary<char, List<NameValue<Guid>>> CodeClassNameValues { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CodeClassNameValues = (await AppService.GetNameValueListAsync(new()
            {
                MaxResultCount = int.MaxValue,
                Sorting = nameof(CodeClassDto.Name),
                IsVisible = true
            }))
            .GroupBy(u => u.Name.First())
            .ToImmutableSortedDictionary(
                u => u.Key,
                u => u.ToList());
    }

    protected string NavUrl(Guid codeClassId) => $"code-docs/browse/{codeClassId}";
}