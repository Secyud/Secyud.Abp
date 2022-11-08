using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Secyud.Abp.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Secyud.Abp.CodeDocsManagement;

[Authorize(CodeDocsPermissions.CodeClass.Default)]
public class CodeClassAppService :
    CrudAppService<CodeClass, CodeClassDto,
        Guid,
        CodeClassGetListInput,
        CodeClassCreateInput,
        CodeClassUpdateInput>,
    ICodeClassAppService
{
    protected override string GetPolicyName => CodeDocsPermissions.CodeClass.Default;
    protected override string GetListPolicyName => CodeDocsPermissions.CodeClass.Default;
    protected override string CreatePolicyName => CodeDocsPermissions.CodeClass.Create;
    protected override string UpdatePolicyName => CodeDocsPermissions.CodeClass.Update;
    protected override string DeletePolicyName => CodeDocsPermissions.CodeClass.Delete;

    protected readonly ICodeClassRepository CodeClassRepository;
    public CodeClassAppService(
        IRepository<CodeClass, Guid> repository, 
        ICodeClassRepository codeClassRepository)
        : base(repository)
    {
        CodeClassRepository = codeClassRepository;
    }
    
    protected override async Task<IQueryable<CodeClass>> CreateFilteredQueryAsync(CodeClassGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .ApplyFilter(name: input.Name,isVisible:input.IsVisible);
    }

    public Task<List<NameValue<Guid>>> GetNameValueListAsync(CodeClassGetListInput input)
    {
        return CodeClassRepository
            .GetNameValueListAsync(
                name: input.Name,
                sorting:input.Sorting,
                skipCount:input.SkipCount,
                maxResultCount:input.MaxResultCount);
    }
}