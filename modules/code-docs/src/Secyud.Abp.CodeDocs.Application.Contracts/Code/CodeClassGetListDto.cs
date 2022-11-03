using Volo.Abp.Application.Dtos;

namespace SuperCreation.Abp.CodeDocs.Code;

public class CodeClassGetListDto : IPagedResultRequest, ISortedResultRequest
{
    public string Sorting { get; set; }
    public int MaxResultCount { get; set; } = int.MaxValue;
    public int SkipCount { get; set; } = 0;
    public string Filter { get; set; } = "";
}
