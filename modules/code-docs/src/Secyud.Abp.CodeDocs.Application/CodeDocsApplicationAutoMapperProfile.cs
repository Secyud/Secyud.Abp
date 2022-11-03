using AutoMapper;
using SuperCreation.Abp.CodeDocs.Code;

namespace SuperCreation.Abp.CodeDocs;

public class CodeDocsApplicationAutoMapperProfile : Profile
{
    public CodeDocsApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<CodeClass, CodeClassSelectDto>();
        CreateMap<CodeClass, CodeClassLookupDto>()
            .ForMember(u => u.ParentName, u => u.MapFrom(x => x.Parent == null ? null : x.Parent.Name));
        CreateMap<FunctionParameter, FunctionParameterDto>();
        CreateMap<CodeFunction, CodeFunctionDto>();
        CreateMap<ClassParameter, ClassParameterDto>();
        CreateMap<CodeClass, CodeClassDto>();
    }
}
