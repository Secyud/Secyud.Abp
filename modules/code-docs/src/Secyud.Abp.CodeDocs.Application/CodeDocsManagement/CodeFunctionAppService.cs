using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Secyud.Abp.Localization;
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
        GetCodeFunctionListInput,
        CreateCodeFunctionInput,
        UpdateCodeFunctionInput>, 
    ICodeFunctionAppService
{
    protected override string GetPolicyName => CodeDocsPermissions.CodeFunction.Default;
    protected override string GetListPolicyName => CodeDocsPermissions.CodeFunction.Default;
    protected override string CreatePolicyName => CodeDocsPermissions.CodeFunction.Create;
    protected override string UpdatePolicyName => CodeDocsPermissions.CodeFunction.Update;
    protected override string DeletePolicyName => CodeDocsPermissions.CodeFunction.Delete;

    protected readonly ICodeFunctionRepository FunctionRepository;
    public CodeFunctionAppService(
        IRepository<CodeFunction, Guid> repository, 
        ICodeFunctionRepository codeFunctionRepository) 
        : base(repository)
    {
        FunctionRepository = codeFunctionRepository;
        LocalizationResource = typeof(CodeDocsResource);
        ObjectMapperContext = typeof(CodeDocsApplicationModule);
    }

    protected override async Task<IQueryable<CodeFunction>> CreateFilteredQueryAsync(GetCodeFunctionListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .ApplyFilter(classId:input.ClassId,name:input.Name);
    }

    public Task<List<NameValue<Guid>>> GetNameValueListAsync(GetCodeFunctionListInput input)
    {
        return FunctionRepository
            .GetNameValueListAsync(
                name: input.Name,
                classId: input.ClassId,
                sorting:input.Sorting,
                skipCount:input.SkipCount,
                maxResultCount:input.MaxResultCount);
    }

    public async Task<List<CodeFunctionDto>> GetListWithDetailsAsync(GetCodeFunctionListInput input)
    {
        var list = await FunctionRepository
            .GetListAsync(
                name: input.Name,
                classId:input.ClassId,
                sorting:input.Sorting,
                skipCount:input.SkipCount,
                maxResultCount:input.MaxResultCount,
                true);

        return ObjectMapper.Map<List<CodeFunction>, List<CodeFunctionDto>>(list);
    }

    public async Task<CodeFunctionDto> AddParameterAsync(Guid id, string name, Guid typeId)
    {
        var entity = await FunctionRepository.GetAsync(id);
        entity.AddParameter(name, typeId);
        entity = await FunctionRepository.UpdateAsync(entity);

        return ObjectMapper.Map<CodeFunction, CodeFunctionDto>(entity);
    }

    public async Task<CodeFunctionDto> RemoveParameterAsync(Guid id, string name)
    {
        var entity = await FunctionRepository.GetAsync(id);
        entity.RemoveParameter(name);
        entity = await FunctionRepository.UpdateAsync(entity);

        return ObjectMapper.Map<CodeFunction, CodeFunctionDto>(entity);
    }

    public async Task<CodeFunctionDto> SetParameterAnnotationAsync(Guid id, string name, string annotation)
    {
        var entity = await FunctionRepository.GetAsync(id);
        entity.GetParameter(name).SetAnnotation(annotation);
        entity = await FunctionRepository.UpdateAsync(entity);

        return ObjectMapper.Map<CodeFunction, CodeFunctionDto>(entity);
    }
}
