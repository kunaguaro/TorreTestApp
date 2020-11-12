using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Domain.Pagination
{
    public class PagingList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PagingList(List<T> items, int count, int pageIndex)
        {
            int pageSize = 10;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public int TotalPageNo
        {
            get
            {
                return TotalPages;
            }
        }

        public static PagingList<T> Create(IQueryable<T> source, int pageIndex, int RecCount = 0)
        {
            int pageSize = 10;
            var count = 0;
   
            if (RecCount < 0)
            {
                count = source.Count();
             
                var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                return new PagingList<T>(items, count, pageIndex);
            }
            else
            {
                count = RecCount;
                var items = source.ToList();
                return new PagingList<T>(items, count, pageIndex);
            }
            

            
        }

        
    }
}