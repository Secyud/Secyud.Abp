using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Secyud.Abp.Localization;
using Secyud.Abp.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Secyud.Abp.CodeDocsManagement;

[Authorize(CodeDocsPermissions.CodeClass.Default)]
public class CodeClassAppService :
    CrudAppService<CodeClass, CodeClassDto,
        Guid,
        GetCodeClassListInput,
        CreateCodeClassInput,
        UpdateCodeClassInput>,
    ICodeClassAppService
{
    protected override string GetPolicyName => CodeDocsPermissions.CodeClass.Default;
    protected override string GetListPolicyName => CodeDocsPermissions.CodeClass.Default;
    protected override string CreatePolicyName => CodeDocsPermissions.CodeClass.Create;
    protected override string UpdatePolicyName => CodeDocsPermissions.CodeClass.Update;
    protected override string DeletePolicyName => CodeDocsPermissions.CodeClass.Delete;

    protected readonly ICodeClassRepository ClassRepository;
    public CodeClassAppService(
        IRepository<CodeClass, Guid> repository, 
        ICodeClassRepository codeClassRepository)
        : base(repository)
    {
        ClassRepository = codeClassRepository;
        LocalizationResource = typeof(CodeDocsResource);
        ObjectMapperContext = typeof(CodeDocsApplicationModule);
    }
    
    protected override async Task<IQueryable<CodeClass>> CreateFilteredQueryAsync(GetCodeClassListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .ApplyFilter(name: input.Name,isVisible:input.IsVisible);
    }

    public Task<List<NameValue<Guid>>> GetNameValueListAsync(GetCodeClassListInput input)
    {
        return ClassRepository
            .GetNameValueListAsync(
                name: input.Name,
                sorting:input.Sorting,
                skipCount:input.SkipCount,
                maxResultCount:input.MaxResultCount);
    }

    public async Task<CodeClassDto> AddParameterAsync(Guid id, string name, Guid typeId)
    {
        var entity = await ClassRepository.GetAsync(id);
        entity.AddParameter(name, typeId);
        entity = await ClassRepository.UpdateAsync(entity);

        return ObjectMapper.Map<CodeClass, CodeClassDto>(entity);
    }

    public async Task<CodeClassDto> RemoveParameterAsync(Guid id, string name)
    {
        var entity = await ClassRepository.GetAsync(id);
        entity.RemoveParameter(name);
        entity = await ClassRepository.UpdateAsync(entity);

        return ObjectMapper.Map<CodeClass, CodeClassDto>(entity);
    }

    public async Task<CodeClassDto> SetParameterAnnotationAsync(Guid id, string name, string annotation)
    {
        var entity = await ClassRepository.GetAsync(id);
        entity.GetParameter(name).SetAnnotation(annotation);
        entity = await ClassRepository.UpdateAsync(entity);

        return ObjectMapper.Map<CodeClass, CodeClassDto>(entity);
    }

    public async Task<CodeClassDto> SetParameterPublicAsync(Guid id, string name)
    {
        var entity = await ClassRepository.GetAsync(id);
        entity.GetParameter(name).SetPublic();
        entity = await ClassRepository.UpdateAsync(entity);

        return ObjectMapper.Map<CodeClass, CodeClassDto>(entity);
    }

    public async Task<CodeClassDto> SetParameterPrivateAsync(Guid id, string name)
    {
        var entity = await ClassRepository.GetAsync(id);
        entity.GetParameter(name).SetPrivate();
        entity = await ClassRepository.UpdateAsync(entity);

        return ObjectMapper.Map<CodeClass, CodeClassDto>(entity);
    }
}