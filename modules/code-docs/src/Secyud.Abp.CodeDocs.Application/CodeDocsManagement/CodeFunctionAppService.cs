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

    protected override string GetPolicyName => CodeDocsPermissions.CodeFunction.Default;
    protected override string GetListPolicyName => CodeDocsPermissions.CodeFunction.Default;
    protected override string CreatePolicyName => CodeDocsPermissions.CodeFunction.Create;
    protected override string UpdatePolicyName => CodeDocsPermissions.CodeFunction.Update;
    protected override string DeletePolicyName => CodeDocsPermissions.CodeFunction.Delete;

    public Task<List<NameValue<Guid>>> GetNameValueListAsync(GetCodeFunctionListInput input)
    {
        return FunctionRepository
            .GetNameValueListAsync(
                input.Name,
                input.ClassId,
                input.Sorting,
                input.SkipCount,
                input.MaxResultCount);
    }

    public async Task<List<CodeFunctionDto>> GetListWithDetailsAsync(GetCodeFunctionListInput input)
    {
        var list = await FunctionRepository
            .GetListAsync(
                input.Name,
                input.ClassId,
                input.Sorting,
                input.SkipCount,
                input.MaxResultCount,
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

    protected override async Task<IQueryable<CodeFunction>> CreateFilteredQueryAsync(GetCodeFunctionListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .ApplyFilter(input.ClassId, input.Name);
    }
}