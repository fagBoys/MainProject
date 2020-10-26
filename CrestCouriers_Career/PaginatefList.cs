using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrestCouriers_Career
{
    public class PaginatefList<T> : List<T>
    {
     public int PageIndex { get; private set; }
     public int TotalPage { get; private set; }

        public PaginatefList(List<T> items , int count , int PageIndex , int PageSize) 
        {
            PageIndex = PageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)PageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPaege
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
                return (PageIndex < TotalPage);
            }
        }

        public static async Task<PaginatefList<T>> CreateAsunc(IQueryable<T> source, int PageIndext, int PageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((PageIndext-1)* PageSize).Take(PageSize).ToListAsync();
            return new PaginatefList<T>(items , count, PageIndext , PageSize);
        }
    }
}
