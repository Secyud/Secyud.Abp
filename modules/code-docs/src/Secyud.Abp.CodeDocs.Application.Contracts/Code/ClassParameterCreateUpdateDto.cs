using JetBrains.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;

public class ClassParameterCreateUpdateDto : EntityDto
{
    [NotNull, MaxLength(CodeConsts.MaxNameLength)] public string Name { get; set; } = "";
    public Guid ClassId { get; set; }

    [Required]
    public Guid TypeId { get; set; }
    [ MaxLength(CodeConsts.MaxAnnotationLength)] public string Annotation { get; set; }
    public bool IsPublic { get; set; }
}
