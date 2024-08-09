namespace Coffee.Paging
{
    public class PagedList<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage { get; set; }
        public List<T> DataSource { get; set; }

        public PagedList()
        {
        }

        public PagedList(List<T> source, int pageIndex, int pageSize, int totalRecord)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalRecord = totalRecord;
            TotalPage = TotalRecord / pageSize;

            if (TotalRecord % pageSize > 0)
                TotalPage++;

            DataSource = source;
        }
    }
}

