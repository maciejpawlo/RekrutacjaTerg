using Microsoft.EntityFrameworkCore;

namespace RekrutacjaTerg.Application.Common.DTOs
{
    public class PagedList<T> where T : class
    {
        public IReadOnlyCollection<T> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public PagedList(IReadOnlyCollection<T> items, int pageNumber, int pageSize, int totalCount)
        {
            Items = items;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> itemsSource, int pageNumber, int pageSize)
        {
            var total = await itemsSource.CountAsync();
            var items = await itemsSource.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, pageNumber, pageSize, total);
        }
    }
}
