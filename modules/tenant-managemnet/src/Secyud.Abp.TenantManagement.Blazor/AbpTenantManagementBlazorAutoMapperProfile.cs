using AutoMapper;
using Volo.Abp.TenantManagement;

namespace Secyud.Abp;

public class AbpTenantManagementBlazorAutoMapperProfile : Profile
{
    public AbpTenantManagementBlazorAutoMapperProfile()
    {
        CreateMap<TenantDto, TenantUpdateDto>()
            .MapExtraProperties();
    }
}