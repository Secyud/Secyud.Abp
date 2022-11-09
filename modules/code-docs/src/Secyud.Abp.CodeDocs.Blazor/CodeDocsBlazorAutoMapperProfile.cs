using AutoMapper;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp.AutoMapper;

namespace Secyud.Abp;

public class CodeDocsBlazorAutoMapperProfile : Profile
{
    public CodeDocsBlazorAutoMapperProfile()
    {
        CreateMap<CodeClassDto, CreateCodeClassInput>()
            .Ignore(u => u.ConcurrencyStamp);
        CreateMap<CodeClassDto, UpdateCodeClassInput>()
            .Ignore(u => u.ConcurrencyStamp);
        CreateMap<CodeFunctionDto, CreateCodeFunctionInput>()
            .Ignore(u => u.ConcurrencyStamp);
        CreateMap<CodeFunctionDto, UpdateCodeFunctionInput>()
            .Ignore(u => u.ConcurrencyStamp);
    }
}
