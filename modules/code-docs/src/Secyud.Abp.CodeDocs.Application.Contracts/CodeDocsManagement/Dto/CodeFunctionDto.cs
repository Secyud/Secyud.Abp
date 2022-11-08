using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;
public class CodeFunctionDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public Guid ClassId { get; set; }
    public Guid? ReturnId { get; set; }
    public string Annotation { get; set; }
    public bool IsStatic { get; set; }
    public bool IsVirtual { get; set; }
    public List<FunctionParameterDto> Parameters { get; set; }
}
