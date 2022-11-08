using System;
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
    public Task<PagedResultDto<CodeClassDto>> GetListAsync(CodeClassGetListInput input)
    {
        return _codeClassAppService.GetListAsync(input);
    }

    [HttpPost]
    public Task<CodeClassDto> CreateAsync(CodeClassCreateInput input)
    {
        return _codeClassAppService.CreateAsync(input);
    }

    [HttpPut]
    public Task<CodeClassDto> UpdateAsync(Guid id, CodeClassUpdateInput input)
    {
        return _codeClassAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
        return _codeClassAppService.DeleteAsync(id);
    }
}
