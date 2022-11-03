using System;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;

public class ClassParameterDto : EntityDto
{
    public string Name { get; set; }
    public Guid ClassId { get; set; }
    public Guid TypeId { get; set; }
    public CodeClassLookupDto Type { get; set; }
    public string Annotation { get; set; }
    public bool IsPublic { get; set; }
}
