using JetBrains.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;
public class CodeFunctionCreateUpdateDto : EntityDto<Guid>
{
    [NotNull, MaxLength(CodeConsts.MaxNameLength)] public string Name { get; set; } = "";
    [MaxLength(CodeConsts.MaxAnnotationLength)]public string Annotation { get; set; }
    public Guid ClassId { get; set; }
    public Guid? ReturnId { get; set; }
    public bool IsStatic { get; set; }
    public bool IsVirtual { get; set; }
}
