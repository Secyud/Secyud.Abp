using System;
using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;

public class ClassParameterDto : EntityDto
{
    public string Name { get; set; }
    public Guid ClassId { get; set; }
    public Guid TypeId { get; set; }
    public string Annotation { get; set; }
    public bool IsPublic { get; set; }
}