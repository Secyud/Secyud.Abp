using Microsoft.AspNetCore.Authorization;
using SuperCreation.Abp.CodeDocs.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;

public class CodeClassAppService : CodeDocsAppService, ICodeClassAppService
{
    private readonly ICodeClassRepository _codeClassRepository;
    private readonly IClassParameterRepository _classParameterRepository;
    private readonly ICodeFunctionRepository _codeFunctionRepository;
    private readonly IFunctionParameterRepository _functionParameterRepository;
    public CodeClassAppService(
        ICodeClassRepository codeClassRepository, IClassParameterRepository classParameterRepository, ICodeFunctionRepository codeFunctionRepository, IFunctionParameterRepository functionParameterRepository)
    {
        _codeClassRepository = codeClassRepository;
        _classParameterRepository = classParameterRepository;
        _codeFunctionRepository = codeFunctionRepository;
        _functionParameterRepository = functionParameterRepository;
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Default)]
    public async Task<PagedResultDto<CodeClassLookupDto>> GetListAsync(CodeClassGetListDto input)
    {
        IQueryable<CodeClass> quarry = 
            (await _codeClassRepository.WithDetailsAsync())
            .WhereIf(!input.Filter.IsNullOrWhiteSpace(),
                x => x.Name.Contains(input.Filter)
                     ||x.Parent.Name.Contains(input.Filter));

        List<CodeClass> list = quarry
            .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? nameof(CodeClass.Name) : input.Sorting)
            .PageBy(input).ToList();

        return new PagedResultDto<CodeClassLookupDto>()
        {
            Items = ObjectMapper.Map<List<CodeClass>,
            List<CodeClassLookupDto>>(list),
            TotalCount = quarry.Count()
        };
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Default)]
    public async Task<List<CodeClassSelectDto>> GetSelectListAsync()
    {
        return ObjectMapper.Map<List<CodeClass>, List<CodeClassSelectDto>>(await _codeClassRepository.GetListAsync());
    }

    [AllowAnonymous]
    public async Task<List<CodeClassSelectDto>> GetBrowseListAsync()
    {
        IQueryable<CodeClass> quarry = await _codeClassRepository.GetQueryableAsync();
        return ObjectMapper.Map<List<CodeClass>, List<CodeClassSelectDto>>(quarry.Where(u => u.IsVisible).OrderBy(u => u.Name).ToList());
    }

    [AllowAnonymous]
    public async Task<CodeClassDto> GetWithDetailsAsync(Guid id)
    {
        CodeClass codeClass = await _codeClassRepository.GetAsync(id);
        codeClass.Parameters = await _classParameterRepository.GetListWithClassIdAsync(id);
        codeClass.Functions = await _codeFunctionRepository.GetListWithClassIdAsync(id);
        foreach (var codeClassFunction in codeClass.Functions)
        {
            codeClassFunction.Parameters = await _functionParameterRepository.GetListWithFunctionIdAsync(codeClassFunction.Id);
        }

        return ObjectMapper.Map<CodeClass, CodeClassDto>(codeClass);
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Default)]
    public async Task<CodeClassDto> GetAsync(Guid id)
    {
        return ObjectMapper.Map<CodeClass, CodeClassDto>(await _codeClassRepository.GetAsync(id));
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Create)]
    public async Task<bool> CreateAsync(CodeClassCreateUpdateDto input)
    {
        return
            await _codeClassRepository.CreateAsync(
                new(GuidGenerator.Create(), input.Name, input.Description, input.Annotation, input.ParentId, input.IsVisible));
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Update)]
    public async Task<bool> UpdateAsync(CodeClassCreateUpdateDto input)
    {
        CodeClass item = await _codeClassRepository.GetAsync(u => u.Id == input.Id, false);
        item.Name = input.Name;
        item.Description = input.Description;
        item.Annotation = input.Annotation;
        item.ParentId = input.ParentId;
        item.IsVisible = input.IsVisible;
        return await _codeClassRepository.UpdateAsync(item);
    }

    [Authorize(CodeDocsPermissions.CodeDocsBasic.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _codeClassRepository
            .DeleteAsync(id);
    }
}
