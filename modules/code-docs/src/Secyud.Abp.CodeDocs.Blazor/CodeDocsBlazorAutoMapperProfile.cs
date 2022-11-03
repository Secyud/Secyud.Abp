using AutoMapper;
using SuperCreation.Abp.CodeDocs.Code;

namespace SuperCreation.Abp.CodeDocs.Blazor;

public class CodeDocsBlazorAutoMapperProfile : Profile
{
    public CodeDocsBlazorAutoMapperProfile()
    {
        CreateMap<CodeClassDto, CodeClassCreateUpdateDto>();
        CreateMap<FunctionParameterDto, FunctionParameterCreateUpdateDto>();
        CreateMap<CodeFunctionDto, CodeFunctionCreateUpdateDto>();
        CreateMap<ClassParameterDto, ClassParameterCreateUpdateDto>();
    }
}
