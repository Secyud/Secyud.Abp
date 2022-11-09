using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;

public class GetCodeClassListInput : ExtensiblePagedAndSortedResultRequestDto
{
    public string Name { get; set; }
    public bool? IsVisible { get; set; }
}