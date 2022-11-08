using System;
using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;

public class CodeFunctionGetListInput : ExtensiblePagedAndSortedResultRequestDto
{
    public string Name { get; set; }
    public Guid ClassId { get; set; }
}