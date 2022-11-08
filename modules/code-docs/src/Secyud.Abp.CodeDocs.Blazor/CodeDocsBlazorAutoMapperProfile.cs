using AutoMapper;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp.AutoMapper;

namespace Secyud.Abp;

public class CodeDocsBlazorAutoMapperProfile : Profile
{
    public CodeDocsBlazorAutoMapperProfile()
    {
        CreateMap<CodeClassDto, CodeClassCreateInput>()
            .Ignore(u => u.ConcurrencyStamp);
        CreateMap<CodeClassDto, CodeClassUpdateInput>()
            .Ignore(u => u.ConcurrencyStamp);
        CreateMap<CodeFunctionDto, CodeFunctionCreateInput>()
            .Ignore(u => u.ConcurrencyStamp);
        CreateMap<CodeFunctionDto, CodeFunctionUpdateInput>()
            .Ignore(u => u.ConcurrencyStamp);
    }
}
