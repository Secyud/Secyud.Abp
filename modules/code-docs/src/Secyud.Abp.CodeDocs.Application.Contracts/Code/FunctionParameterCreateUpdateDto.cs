using JetBrains.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;

public class FunctionParameterCreateUpdateDto : EntityDto
{
    [NotNull, MaxLength(CodeConsts.MaxNameLength)] public string Name { get; set; } = "";

    public Guid FunctionId { get; set; }

    [Required]
    public Guid TypeId { get; set; }

    [MaxLength(CodeConsts.MaxAnnotationLength)] public string Annotation { get; set; }
    
}
