using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Secyud.Abp.Permissions;
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
    
    public CodeFunctionAppService(IRepository<CodeFunction, Guid> repository) 
        : base(repository)
    {
    }

    protected override async Task<IQueryable<CodeFunction>> CreateFilteredQueryAsync(CodeFunctionGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .ApplyFilter(classId:input.ClassId,name:input.Name);
    }
}
