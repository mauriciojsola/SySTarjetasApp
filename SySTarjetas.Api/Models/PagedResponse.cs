using System.Collections.Generic;

namespace SySTarjetas.Api.Models
{
    public class PagedResponse<T> where T : class
    {
        public IList<T> Items { get; protected set; }
        public int PageIndex { get; protected set; }
        public int PageSize { get; protected set; }
        public int TotalCount { get; protected set; }

        public PagedResponse(IList<T> items, int pageIndex, int pageSize, int totalCount)
        {
            Items = items;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

    }
}