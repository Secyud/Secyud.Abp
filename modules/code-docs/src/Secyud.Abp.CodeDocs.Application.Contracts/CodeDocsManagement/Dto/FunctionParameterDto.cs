using System;
using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;

public class FunctionParameterDto : EntityDto
{
    public string Name { get; set; }
    public Guid FunctionId { get; set; }
    public Guid TypeId { get; set; }
    public string Annotation { get; set; }
}