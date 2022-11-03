using Microsoft.AspNetCore.Authorization;
using SuperCreation.Abp.CodeDocs.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperCreation.Abp.CodeDocs.Code;

public class ClassParameterAppService : CodeDocsAppService, IClassParameterAppService
{
    private readonly IClassParameterRepository _classParameterRepository;

    public ClassParameterAppService(IClassParameterRepository classParameterRepository)
    {
        _classParameterRepository = classParameterRepository;
    }

    public async Task<List<ClassParameterDto>> GetAllWithClassIdAsync(Guid classId)
    {
        return ObjectMapper.Map<List<ClassParameter>, List<ClassParameterDto>>(await _classParameterRepository.GetListWithClassIdAsync(classId));
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Create)]
    public async Task<bool> CreateAsync(ClassParameterCreateUpdateDto input)
    {
        return await _classParameterRepository.CreateAsync(
            new(input.Name, input.ClassId, input.TypeId, input.Annotation, input.IsPublic));
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Update)]
    public async Task<bool> UpdateAsync(ClassParameterCreateUpdateDto input)
    {
        ClassParameter item = await _classParameterRepository.GetAsync(u => u.Name == input.Name && u.ClassId == input.ClassId, false);
        item.TypeId = input.TypeId;
        item.Annotation = input.Annotation;
        item.IsPublic = input.IsPublic;
        return await _classParameterRepository.UpdateAsync(item);
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Delete)]
    public async Task DeleteAsync(Guid classId, string name)
    {
        await _classParameterRepository.DeleteAsync(classId, name);
    }
}
