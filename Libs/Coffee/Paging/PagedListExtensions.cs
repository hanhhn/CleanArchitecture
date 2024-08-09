using Coffee.Exceptions;

namespace Coffee.Paging
{
    public static class PagedListExtensions
    {
        public static PagedList<TSource> ToPagedList<TSource>(this IQueryable<TSource> query, int pageIndex, int pageSize) where TSource : class
        {
            if (!(pageIndex >= 0 && pageSize >= 1))
                throw new InformationException(string.Format("Something wrong with pageIndex: {0} or pageSize: {1}", pageIndex, pageSize));

            var querySource = query.Skip(pageIndex * pageSize).Take(pageSize);
            int totalRecord = querySource.Count();
            var source = querySource.ToList();

            return new PagedList<TSource>(source, pageIndex, pageSize, totalRecord);
        }
    }
}

