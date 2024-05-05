namespace Dr_Purple.Application.Utility.Paging;
public class PagedResult<T> : PagedResultBase where T : class
{
    public ICollection<T> Results { get; set; }
    public PagedResult()
        => Results = new HashSet<T>();
}