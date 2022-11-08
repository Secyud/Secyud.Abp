using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Secyud.Abp.CodeDocsManagement;

public abstract class CodeClassCreateUpdateDtoBase: ExtensibleEntityDto,IHasConcurrencyStamp
{
    [Required,StringLength(CodeDocsConsts.MaxNameLength)] public string Name { get; set; }
    [StringLength(CodeDocsConsts.MaxDescriptionLength)] public string Description { get; set; }
    [StringLength(CodeDocsConsts.MaxAnnotationLength)] public string Annotation { get; set; }
    public Guid ParentId { get; set; }
    public bool IsVisible { get; set; }
    
    public string ConcurrencyStamp { get; set; }
}
