using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace SuperCreation.Abp.CodeDocs.Code;

[Area(CodeDocsRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CodeDocsRemoteServiceConsts.RemoteServiceName)]
[Route("api/code-docs/code-function")]
public class CodeFunctionController : CodeDocsController, ICodeFunctionAppService
{
    private readonly ICodeFunctionAppService _codeFunctionAppService;

    public CodeFunctionController(ICodeFunctionAppService codeFunctionAppService)
    {
        _codeFunctionAppService = codeFunctionAppService;
    }

    [HttpGet]
    public Task<List<CodeFunctionDto>> GetAllWithClassIdAsync(Guid classId)
    {
        return _codeFunctionAppService.GetAllWithClassIdAsync(classId);
    }

    [HttpGet, Route("details")]
    public Task<CodeFunctionDto> GetWithDetailsAsync(Guid id)
    {
        return _codeFunctionAppService.GetWithDetailsAsync(id);
    }

    [HttpPost]
    public Task<bool> CreateAsync(CodeFunctionCreateUpdateDto input)
    {
        return _codeFunctionAppService.CreateAsync(input);
    }
    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
        return _codeFunctionAppService.DeleteAsync(id);
    }
    [HttpPut]
    public Task<bool> UpdateAsync(CodeFunctionCreateUpdateDto input)
    {
        return _codeFunctionAppService.UpdateAsync(input);
    }
}
