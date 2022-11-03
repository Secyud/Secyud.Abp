using JetBrains.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;

public class CodeClassCreateUpdateDto : EntityDto<Guid>
{
    [NotNull,MinLength(1),MaxLength(CodeConsts.MaxNameLength)] public string Name { get; set; } = "";
    [MaxLength(CodeConsts.MaxDescriptionLength)] public string Description { get; set; }
    [MaxLength(CodeConsts.MaxAnnotationLength)] public string Annotation { get; set; }
    public Guid? ParentId { get; set; }
    public bool IsVisible { get; set; }
}
