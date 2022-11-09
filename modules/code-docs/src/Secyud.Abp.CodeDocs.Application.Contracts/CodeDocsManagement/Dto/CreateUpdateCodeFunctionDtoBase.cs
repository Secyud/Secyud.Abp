using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Secyud.Abp.CodeDocsManagement;

public abstract class CreateUpdateCodeFunctionDtoBase : ExtensibleEntityDto, IHasConcurrencyStamp
{
    [Required]
    [StringLength(CodeDocsConsts.MaxNameLength, MinimumLength = 1)]
    public string Name { get; set; }

    [StringLength(CodeDocsConsts.MaxAnnotationLength)]
    public string Annotation { get; set; } = string.Empty;

    public Guid ClassId { get; set; }
    public Guid ReturnId { get; set; }
    public bool IsStatic { get; set; }
    public bool IsVirtual { get; set; }
    public string ConcurrencyStamp { get; set; }
}