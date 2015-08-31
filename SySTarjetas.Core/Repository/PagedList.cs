using System.Linq;

namespace SySTarjetas.Core.Repository
{
    public class PagedList<T> where T : class
    {
        private readonly IQueryable<T> _list;
        private readonly int? _pageIndex;
        private readonly int? _pageSize;
        private const int DefaultPageSize = 25;

        public PagedList(IQueryable<T> list, int? pageIndex = null, int? pageSize = null)
        {
            _list = list;
            _pageIndex = pageIndex;
            _pageSize = pageSize;
        }

        /// <summary>
        /// The paginated result
        /// </summary>
        public IQueryable<T> Items
        {
            get
            {
                return _list == null ? null : _list.Skip((PageIndex - 1) * PageSize).Take(PageSize);
            }
        }

        /// <summary>
        ///  The current page.
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _pageIndex ?? 1;
            }
        }

        public int PageSize
        {
            get
            {
                return _pageSize ?? (_list == null ? 0
                    : DefaultPageSize);
            }
        }

        public int TotalCount
        {
            get
            {
                return _list == null ? 0 : _list.Count();
            }
        }
    }
}
