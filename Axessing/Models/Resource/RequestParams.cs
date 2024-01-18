using Axessing.Models.Schema;

namespace Axessing.Models.Resource;

public class RequestParams
{
    public Stage? Stage { get; set; }
    public int? WorkspaceId { get; set; }
    public bool? Backlog { get; set; }
    public int? Take { get; set; }
    public int? PageSize { get; set; }
    public int? PageCount { get; set; }
}
