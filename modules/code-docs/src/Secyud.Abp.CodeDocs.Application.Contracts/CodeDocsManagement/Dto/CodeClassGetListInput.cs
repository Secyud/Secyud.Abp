using Volo.Abp.Application.Dtos;

namespace Secyud.Abp.CodeDocsManagement;

public class CodeClassGetListInput : ExtensiblePagedAndSortedResultRequestDto
{
    public string Name { get; set; }
    public bool? IsVisible { get; set; }
}
