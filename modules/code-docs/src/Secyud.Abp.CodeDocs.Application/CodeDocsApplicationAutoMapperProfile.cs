using AutoMapper;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp.AutoMapper;

namespace Secyud.Abp;

public class CodeDocsApplicationAutoMapperProfile : Profile
{
    public CodeDocsApplicationAutoMapperProfile()
    {
        CreateMap<ClassParameter,ClassParameterDto>();
        
        CreateMap<CodeClass,CodeClassDto>();
        CreateMap<CodeClassCreateInput,CodeClass>()
            .Ignore(u=>u.Id)
            .Ignore(u=>u.Parameters)
            .IgnoreFullAuditedObjectProperties();
        CreateMap<CodeClassUpdateInput,CodeClass>()
            .Ignore(u=>u.Id)
            .Ignore(u=>u.Parameters)
            .IgnoreFullAuditedObjectProperties();

        CreateMap<FunctionParameter,FunctionParameterDto>();

        CreateMap<CodeFunction,CodeFunctionDto>();
        CreateMap<CodeFunctionCreateInput,CodeFunction>()
            .Ignore(u=>u.Id)
            .Ignore(u=>u.Parameters)
            .IgnoreAuditedObjectProperties();
        CreateMap<CodeFunctionUpdateInput,CodeFunction>()
            .Ignore(u=>u.Id)
            .Ignore(u=>u.Parameters)
            .IgnoreAuditedObjectProperties();
    }
}
