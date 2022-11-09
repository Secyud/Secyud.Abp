using System;
using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;

public class GetCodeFunctionListInput : ExtensiblePagedAndSortedResultRequestDto
{
    public string Name { get; set; }
    public Guid ClassId { get; set; }
}