using JetBrains.Annotations;
using System;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;

public class FunctionParameterDto : EntityDto
{
    [NotNull] public string Name { get; set; } = "";

    public Guid FunctionId { get; set; }
    public Guid TypeId { get; set; }
    public CodeClassLookupDto Type { get; set; }

    public string Annotation { get; set; }
}
