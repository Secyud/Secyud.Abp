using Microsoft.AspNetCore.Authorization;
using SuperCreation.Abp.CodeDocs.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperCreation.Abp.CodeDocs.Code;

public class FunctionParameterAppService : CodeDocsAppService, IFunctionParameterAppService
{
    private readonly IFunctionParameterRepository _functionParameterRepository;

    public FunctionParameterAppService(IFunctionParameterRepository functionParameterRepository)
    {
        _functionParameterRepository = functionParameterRepository;
    }

    public async Task<List<FunctionParameterDto>> GetAllWithFunctionIdAsync(Guid functionId)
    {
        return ObjectMapper.Map<List<FunctionParameter>, List<FunctionParameterDto>>(await _functionParameterRepository.GetListWithFunctionIdAsync(functionId));
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Create)]
    public async Task<bool> CreateAsync(FunctionParameterCreateUpdateDto input)
    {
        return await _functionParameterRepository.CreateAsync(
            new(input.Name, input.FunctionId, input.TypeId, input.Annotation));
    }


    [Authorize(CodeDocsPermissions.CodeDocsBasic.Update)]
    public async Task<bool> UpdateAsync(FunctionParameterCreateUpdateDto input)
    {
        FunctionParameter item = await _functionParameterRepository.GetAsync(u => u.Name == input.Name && u.FunctionId == input.FunctionId, false);
        item.TypeId = input.TypeId;
        item.Annotation = input.Annotation;
        return await _functionParameterRepository.UpdateAsync(item);
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Delete)]
    public async Task DeleteAsync(Guid functionId, string name)
    {
        await _functionParameterRepository.DeleteAsync(functionId, name);
    }
}
