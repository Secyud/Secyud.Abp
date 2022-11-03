using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;

[Area(CodeDocsRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CodeDocsRemoteServiceConsts.RemoteServiceName)]
[Route("api/code-docs/code-class")]
public class CodeClassController : CodeDocsController, ICodeClassAppService
{
    private readonly ICodeClassAppService _codeClassAppService;

    public CodeClassController(ICodeClassAppService codeClassAppService)
    {
        _codeClassAppService = codeClassAppService;
    }

    [HttpGet,Route("select-list")]
    public Task<List<CodeClassSelectDto>> GetSelectListAsync()
    {
        return _codeClassAppService.GetSelectListAsync();
    }

    [HttpGet, Route("browse-list")]
    public Task<List<CodeClassSelectDto>> GetBrowseListAsync()
    {
        return _codeClassAppService.GetBrowseListAsync();
    }

    [HttpPost]
    public Task<bool> CreateAsync(CodeClassCreateUpdateDto input)
    {
        return _codeClassAppService.CreateAsync(input);
    }

    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
        return _codeClassAppService.DeleteAsync(id);
    }

    [HttpGet, Route("with-details")]
    public Task<CodeClassDto> GetWithDetailsAsync(Guid id)
    {
        return _codeClassAppService.GetWithDetailsAsync(id);
    }

    [HttpGet,Route("get-list")]
    public Task<PagedResultDto<CodeClassLookupDto>> GetListAsync(CodeClassGetListDto input)
    {
        return _codeClassAppService.GetListAsync(input);
    }

    [HttpGet]
    public Task<CodeClassDto> GetAsync(Guid id)
    {
        return _codeClassAppService.GetAsync(id);
    }
    [HttpPut]
    public Task<bool> UpdateAsync(CodeClassCreateUpdateDto input)
    {
        return _codeClassAppService.UpdateAsync(input);
    }
}
