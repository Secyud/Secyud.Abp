using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;

public class FunctionParameterDto : EntityDto
{
    [Required] public string Name { get; set; } = "";

    public Guid FunctionId { get; set; }
    public Guid TypeId { get; set; }
    public string Annotation { get; set; }
}
