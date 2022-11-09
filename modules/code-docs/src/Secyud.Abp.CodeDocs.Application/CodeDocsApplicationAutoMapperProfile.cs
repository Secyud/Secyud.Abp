using AutoMapper;
using Secyud.Abp.CodeDocsManagement;
using Volo.Abp.AutoMapper;

namespace Secyud.Abp;

public class CodeDocsApplicationAutoMapperProfile : Profile
{
    public CodeDocsApplicationAutoMapperProfile()
    {
        CreateMap<ClassParameter, ClassParameterDto>();

        CreateMap<CodeClass, CodeClassDto>();
        CreateMap<CreateCodeClassInput, CodeClass>()
            .Ignore(u => u.Id)
            .Ignore(u => u.Parameters)
            .IgnoreFullAuditedObjectProperties();
        CreateMap<UpdateCodeClassInput, CodeClass>()
            .Ignore(u => u.Id)
            .Ignore(u => u.Parameters)
            .IgnoreFullAuditedObjectProperties();

        CreateMap<FunctionParameter, FunctionParameterDto>();

        CreateMap<CodeFunction, CodeFunctionDto>();
        CreateMap<CreateCodeFunctionInput, CodeFunction>()
            .Ignore(u => u.Id)
            .Ignore(u => u.Parameters)
            .IgnoreAuditedObjectProperties();
        CreateMap<UpdateCodeFunctionInput, CodeFunction>()
            .Ignore(u => u.Id)
            .Ignore(u => u.Parameters)
            .IgnoreAuditedObjectProperties();
    }
}