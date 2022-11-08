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

[Authorize(CodeDocsPermissions.CodeFunction.Default)]
public class CodeFunctionAppService :
    CrudAppService<
        CodeFunction,
        CodeFunctionDto,
        Guid,
        CodeFunctionGetListInput,
        CodeFunctionCreateInput,
        CodeFunctionUpdateInput>, 
    ICodeFunctionAppService
{
    protected override string GetPolicyName => CodeDocsPermissions.CodeFunction.Default;
    protected override string GetListPolicyName => CodeDocsPermissions.CodeFunction.Default;
    protected override string CreatePolicyName => CodeDocsPermissions.CodeFunction.Create;
    protected override string UpdatePolicyName => CodeDocsPermissions.CodeFunction.Update;
    protected override string DeletePolicyName => CodeDocsPermissions.CodeFunction.Delete;

    protected readonly ICodeFunctionRepository CodeFunctionRepository;
    public CodeFunctionAppService(
        IRepository<CodeFunction, Guid> repository, 
        ICodeFunctionRepository codeFunctionRepository) 
        : base(repository)
    {
        CodeFunctionRepository = codeFunctionRepository;
    }

    protected override async Task<IQueryable<CodeFunction>> CreateFilteredQueryAsync(CodeFunctionGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .ApplyFilter(classId:input.ClassId,name:input.Name);
    }

    public Task<List<NameValue<Guid>>> GetNameValueListAsync(CodeFunctionGetListInput input)
    {
        return CodeFunctionRepository
            .GetNameValueListAsync(
                name: input.Name,
                classId: input.ClassId,
                sorting:input.Sorting,
                skipCount:input.SkipCount,
                maxResultCount:input.MaxResultCount);
    }

    public async Task<List<CodeFunctionDto>> GetListWithDetailsAsync(CodeFunctionGetListInput input)
    {
        var list = await CodeFunctionRepository
            .GetListAsync(
                name: input.Name,
                classId:input.ClassId,
                sorting:input.Sorting,
                skipCount:input.SkipCount,
                maxResultCount:input.MaxResultCount,
                true);

        return ObjectMapper.Map<List<CodeFunction>, List<CodeFunctionDto>>(list);
    }
}
