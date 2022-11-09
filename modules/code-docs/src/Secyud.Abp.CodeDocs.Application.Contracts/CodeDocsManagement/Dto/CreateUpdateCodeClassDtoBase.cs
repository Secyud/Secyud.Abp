using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Secyud.Abp.CodeDocsManagement;

public abstract class CreateUpdateCodeClassDtoBase: ExtensibleEntityDto,IHasConcurrencyStamp
{
    [Required,StringLength(CodeDocsConsts.MaxNameLength,MinimumLength = 1)]
    public string Name { get; set; }

    [StringLength(CodeDocsConsts.MaxDescriptionLength)]
    public string Description { get; set; } = string.Empty;

    [StringLength(CodeDocsConsts.MaxAnnotationLength)]
    public string Annotation { get; set; } = string.Empty;
    public Guid ParentId { get; set; }
    public bool IsVisible { get; set; }
    
    public string ConcurrencyStamp { get; set; }
}
