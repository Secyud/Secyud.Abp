using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;

public class CodeFunctionController : CodeDocsController, ICodeFunctionAppService
{
    private readonly ICodeFunctionAppService _codeFunctionAppService;

    public CodeFunctionController(ICodeFunctionAppService codeFunctionAppService)
    {
        _codeFunctionAppService = codeFunctionAppService;
    }

    [HttpGet]
    public Task<CodeFunctionDto> GetAsync(Guid id)
    {
        return _codeFunctionAppService.GetAsync(id);
    }

    [HttpGet]
    [Route("list")]
    public Task<PagedResultDto<CodeFunctionDto>> GetListAsync(GetCodeFunctionListInput input)
    {
        return _codeFunctionAppService.GetListAsync(input);
    }

    [HttpPost]
    public Task<CodeFunctionDto> CreateAsync(CreateCodeFunctionInput input)
    {
        return _codeFunctionAppService.CreateAsync(input);
    }

    [HttpPut]
    public Task<CodeFunctionDto> UpdateAsync(Guid id, UpdateCodeFunctionInput input)
    {
        return _codeFunctionAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
        return _codeFunctionAppService.DeleteAsync(id);
    }

    [HttpGet]
    [Route("name-value-list")]
    public Task<List<NameValue<Guid>>> GetNameValueListAsync(GetCodeFunctionListInput input)
    {
        return _codeFunctionAppService.GetNameValueListAsync(input);
    }

    [HttpGet]
    [Route("detailed-list")]
    public Task<List<CodeFunctionDto>> GetListWithDetailsAsync(GetCodeFunctionListInput input)
    {
        return _codeFunctionAppService.GetListWithDetailsAsync(input);
    }

    [HttpPost]
    [Route("parameter")]
    public Task<CodeFunctionDto> AddParameterAsync(Guid id, string name, Guid typeId)
    {
        return _codeFunctionAppService.AddParameterAsync(id, name, typeId);
    }

    [HttpDelete]
    [Route("parameter")]
    public Task<CodeFunctionDto> RemoveParameterAsync(Guid id, string name)
    {
        return _codeFunctionAppService.RemoveParameterAsync(id, name);
    }

    [HttpPut]
    [Route("parameter/annotation")]
    public Task<CodeFunctionDto> SetParameterAnnotationAsync(Guid id, string name, string annotation)
    {
        return _codeFunctionAppService.SetParameterAnnotationAsync(id, name, annotation);
    }
}