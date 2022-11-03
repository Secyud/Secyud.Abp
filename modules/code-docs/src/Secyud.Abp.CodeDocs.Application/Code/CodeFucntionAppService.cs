using Microsoft.AspNetCore.Authorization;
using SuperCreation.Abp.CodeDocs.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCreation.Abp.CodeDocs.Code;

public class CodeFunctionAppService : CodeDocsAppService, ICodeFunctionAppService
{
    private readonly ICodeFunctionRepository _codeFunctionRepository;

    public CodeFunctionAppService(ICodeFunctionRepository codeFunctionRepository)
    {
        _codeFunctionRepository = codeFunctionRepository;
    }

    public async Task<List<CodeFunctionDto>> GetAllWithClassIdAsync(Guid classId)
    {
        return ObjectMapper.Map<List<CodeFunction>, List<CodeFunctionDto>>(await _codeFunctionRepository.GetListWithClassIdAsync(classId));
    }

    public async Task<CodeFunctionDto> GetWithDetailsAsync(Guid id)
    {
        var quarry = await _codeFunctionRepository.WithDetailsAsync();
        return ObjectMapper.Map<CodeFunction, CodeFunctionDto>(quarry.First(u => u.Id == id));
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Create)]
    public async Task<bool> CreateAsync(CodeFunctionCreateUpdateDto input)
    {
        return await _codeFunctionRepository.CreateAsync(
            new(GuidGenerator.Create(),
            input.Name, input.Annotation, input.ClassId,
            input.ReturnId, input.IsStatic, input.IsVirtual));
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Update)]
    public async Task<bool> UpdateAsync(CodeFunctionCreateUpdateDto input)
    {
        CodeFunction item = await _codeFunctionRepository.GetAsync(u => u.Id == input.Id, false);
        item.Name = input.Name;
        item.Annotation = input.Annotation;
        item.ClassId = input.ClassId;
        item.ReturnId = input.ReturnId;
        item.IsStatic = input.IsStatic;
        item.IsVirtual = input.IsVirtual;
        return await _codeFunctionRepository.UpdateAsync(item);
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _codeFunctionRepository.DeleteAsync(id);
    }
}
