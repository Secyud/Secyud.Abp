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

    [HttpGet,Route("list")]
    public Task<PagedResultDto<CodeFunctionDto>> GetListAsync(CodeFunctionGetListInput input)
    {
        return _codeFunctionAppService.GetListAsync(input);
    }
    
    [HttpPost]
    public Task<CodeFunctionDto> CreateAsync(CodeFunctionCreateInput input)
    {
        return _codeFunctionAppService.CreateAsync(input);
    }

    [HttpPut]
    public Task<CodeFunctionDto> UpdateAsync(Guid id, CodeFunctionUpdateInput input)
    {
        return _codeFunctionAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
        return _codeFunctionAppService.DeleteAsync(id);
    }

    [HttpGet,Route("name-value-list")]
    public Task<List<NameValue<Guid>>> GetNameValueListAsync(CodeFunctionGetListInput input)
    {
        return _codeFunctionAppService.GetNameValueListAsync(input);
    }

    [HttpGet,Route("detailed-list")]
    public Task<List<CodeFunctionDto>> GetListWithDetailsAsync(CodeFunctionGetListInput input)
    {
        return _codeFunctionAppService.GetListWithDetailsAsync(input);
    }
}