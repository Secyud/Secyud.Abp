using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SuperCreation.Abp.CodeDocs.Code;

public interface ICodeClassAppService : IApplicationService
{
    Task<CodeClassDto> GetAsync(Guid id);
    Task<CodeClassDto> GetWithDetailsAsync(Guid id);

    Task<PagedResultDto<CodeClassLookupDto>> GetListAsync(CodeClassGetListDto input);
    Task<List<CodeClassSelectDto>> GetSelectListAsync();
    Task<List<CodeClassSelectDto>> GetBrowseListAsync();
    Task<bool> CreateAsync(CodeClassCreateUpdateDto input);
    Task<bool> UpdateAsync(CodeClassCreateUpdateDto input);
    Task DeleteAsync(Guid id);
}
