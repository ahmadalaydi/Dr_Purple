using System.Linq.Dynamic.Core;

namespace Dr_Purple.Application.Utility.Paging;
public static class QueryableExtensions
{
    public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
    {
        var result = new PagedResult<T>
        {
            CurrentPage = page,
            PageSize = pageSize,
            RowCount = query.Count()
        };

        var pageCount = (double)result.RowCount / pageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;
        result.Results = query/*.OrderBy("id")*/.Skip(skip).Take(pageSize).ToHashSet();

        return result;
    }

    public static IQueryable<T> Sort<T>(this IQueryable<T> query, string orderBy)
    {
        if (!string.IsNullOrWhiteSpace(orderBy))
        {
            query = query.OrderBy(orderBy);
        }
        return query;
    }
    public static IQueryable<T> Search<T>(this IQueryable<T> query, string searchBy)
    {
        if (!string.IsNullOrWhiteSpace(searchBy))
        {
            query = query.Where(searchBy);
        }
        return query;
    }
}