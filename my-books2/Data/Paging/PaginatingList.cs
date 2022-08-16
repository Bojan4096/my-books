namespace my_books2.Data.Paging
{
    public class PaginatingList<T>: List<T>
    {
        public int pageIndex { get; set; }
        public int totalPages { get; private set; }

        public PaginatingList(List<T> items, int count, int thePageIndex, int pageSize)
        {
            pageIndex = thePageIndex;
            totalPages = (int)Math.Ceiling(count/(double)pageSize);

            this.AddRange(items);
        }

        public bool hasPreviousPage
        {
            get
            {
                return pageIndex > 1;
            }
        }
        public bool hasNextPage
        {
            get
            {
                return pageIndex < totalPages;
            }
        }

        public static PaginatingList<T> create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
            return new PaginatingList<T>(items, count, pageIndex, pageSize);
        }
    }
}
