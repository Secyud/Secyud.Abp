using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;

[Area(CodeDocsRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CodeDocsRemoteServiceConsts.RemoteServiceName)]
[Route("api/code-docs/sample")]
public class CodeClassController : CodeDocsController, ICodeClassAppService
{
    private readonly ICodeClassAppService _codeClassAppService;

    public CodeClassController(ICodeClassAppService codeClassAppService)
    {
        _codeClassAppService = codeClassAppService;
    }

    [HttpGet]
    public Task<CodeClassDto> GetAsync(Guid id)
    {
        return _codeClassAppService.GetAsync(id);
    }

    [HttpGet,Route("list")]
    public Task<PagedResultDto<CodeClassDto>> GetListAsync(GetCodeClassListInput input)
    {
        return _codeClassAppService.GetListAsync(input);
    }
    
    [HttpPost]
    public Task<CodeClassDto> CreateAsync(CreateCodeClassInput input)
    {
        return _codeClassAppService.CreateAsync(input);
    }

    [HttpPut]
    public Task<CodeClassDto> UpdateAsync(Guid id, UpdateCodeClassInput input)
    {
        return _codeClassAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
        return _codeClassAppService.DeleteAsync(id);
    }

    [HttpGet,Route("name-value-list")]
    public Task<List<NameValue<Guid>>> GetNameValueListAsync(GetCodeClassListInput input)
    {
        return _codeClassAppService.GetNameValueListAsync(input);
    }

    [HttpPost,Route("parameter")]
    public Task<CodeClassDto> AddParameterAsync(Guid id, string name, Guid typeId)
    {
        return _codeClassAppService.AddParameterAsync(id, name, typeId);
    }

    [HttpDelete,Route("parameter")]
    public Task<CodeClassDto> RemoveParameterAsync(Guid id, string name)
    {
        return _codeClassAppService.RemoveParameterAsync(id, name);
    }

    [HttpPut,Route("parameter/annotation")]
    public Task<CodeClassDto> SetParameterAnnotationAsync(Guid id, string name, string annotation)
    {
        return _codeClassAppService.SetParameterAnnotationAsync(id, name, annotation);
    }

    [HttpPut,Route("parameter/public")]
    public Task<CodeClassDto> SetParameterPublicAsync(Guid id, string name)
    {
        return _codeClassAppService.SetParameterPublicAsync(id, name);
    }

    [HttpPut,Route("parameter/private")]
    public Task<CodeClassDto> SetParameterPrivateAsync(Guid id, string name)
    {
        return _codeClassAppService.SetParameterPrivateAsync(id, name);
    }
}
