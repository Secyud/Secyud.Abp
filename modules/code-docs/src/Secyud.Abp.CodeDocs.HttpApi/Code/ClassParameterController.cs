using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;

namespace SuperCreation.Abp.CodeDocs.Code;

[Area(CodeDocsRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CodeDocsRemoteServiceConsts.RemoteServiceName)]
[Route("api/code-docs/class-parameter")]
public class ClassParameterController : CodeDocsController, IClassParameterAppService
{
    private readonly IClassParameterAppService _classParameterAppService;

    public ClassParameterController(IClassParameterAppService classParameterAppService)
    {
        _classParameterAppService = classParameterAppService;
    }

    [HttpGet]
    public Task<List<ClassParameterDto>> GetAllWithClassIdAsync(Guid classId)
    {
        return _classParameterAppService.GetAllWithClassIdAsync(classId);
    }

    [HttpPost]
    public Task<bool> CreateAsync(ClassParameterCreateUpdateDto input)
    {
        return _classParameterAppService.CreateAsync(input);
    }
    [HttpDelete]
    public Task DeleteAsync(Guid classId, string name)
    {
        return _classParameterAppService.DeleteAsync(classId, name);
    }
    [HttpPut]
    public Task<bool> UpdateAsync(ClassParameterCreateUpdateDto input)
    {
        return _classParameterAppService.UpdateAsync(input);
    }
}
