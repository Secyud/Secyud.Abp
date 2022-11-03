using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;

namespace SuperCreation.Abp.CodeDocs.Code;

[Area(CodeDocsRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CodeDocsRemoteServiceConsts.RemoteServiceName)]
[Route("api/code-docs/function-parameter")]
public class FunctionParameterController : CodeDocsController, IFunctionParameterAppService
{
    private readonly IFunctionParameterAppService _functionParameterAppService;

    public FunctionParameterController(IFunctionParameterAppService functionParameterAppService)
    {
        _functionParameterAppService = functionParameterAppService;
    }

    [HttpGet]
    public Task<List<FunctionParameterDto>> GetAllWithFunctionIdAsync(Guid functionId)
    {
        return _functionParameterAppService.GetAllWithFunctionIdAsync(functionId);
    }

    [HttpPost]
    public Task<bool> CreateAsync(FunctionParameterCreateUpdateDto input)
    {
        return _functionParameterAppService.CreateAsync(input);
    }
    [HttpDelete]
    public Task DeleteAsync(Guid classId, string name)
    {
        return _functionParameterAppService.DeleteAsync(classId, name);
    }
    [HttpPut]
    public Task<bool> UpdateAsync(FunctionParameterCreateUpdateDto input)
    {
        return _functionParameterAppService.UpdateAsync(input);
    }
}
