// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;
using SuperCreation.Abp.CodeDocs.Code;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace SuperCreation.Abp.CodeDocs.Code.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IFunctionParameterAppService), typeof(FunctionParameterClientProxy))]
public partial class FunctionParameterClientProxy : ClientProxyBase<IFunctionParameterAppService>, IFunctionParameterAppService
{
    public virtual async Task<List<FunctionParameterDto>> GetAllWithFunctionIdAsync(Guid functionId)
    {
        return await RequestAsync<List<FunctionParameterDto>>(nameof(GetAllWithFunctionIdAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), functionId }
        });
    }

    public virtual async Task<bool> CreateAsync(FunctionParameterCreateUpdateDto input)
    {
        return await RequestAsync<bool>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(FunctionParameterCreateUpdateDto), input }
        });
    }

    public virtual async Task DeleteAsync(Guid classId, string name)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), classId },
            { typeof(string), name }
        });
    }

    public virtual async Task<bool> UpdateAsync(FunctionParameterCreateUpdateDto input)
    {
        return await RequestAsync<bool>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(FunctionParameterCreateUpdateDto), input }
        });
    }
}