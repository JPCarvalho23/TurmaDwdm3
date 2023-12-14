using Microsoft.EntityFrameworkCore;

namespace TurmaDwdm3
{
    public class PaginaList<T> : List<T>
    {
        public int PaginaIndex { get; private set; }
        public int TotalPaginas { get; private set; }
        public PaginaList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PaginaIndex = pageIndex;
            TotalPaginas = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        public bool HasPreviousPage
        {
            get
            {
                return (PaginaIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PaginaIndex < TotalPaginas);
            }
        }
        public static async Task<PaginaList<T>> CreateAsync(
        IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize)
            .Take(pageSize).ToListAsync();
            return new PaginaList<T>(items, count, pageIndex, pageSize);
        }
    }
}
