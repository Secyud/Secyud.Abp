using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;

public class CodeClassDto : EntityDto<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Annotation { get; set; }

    public CodeClassLookupDto Parent { get; set; }
    public bool IsVisible { get; set; }
    public List<ClassParameterDto> Parameters { get; set; }

    public List<CodeFunctionDto> Functions { get; set; }
}
