using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;

public class CodeClassDto : ExtensibleEntityDto<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Annotation { get; set; }

    public Guid ParentId { get; set; }

    public bool IsVisible { get; set; }

    public List<ClassParameterDto> Parameters { get; set; }
}