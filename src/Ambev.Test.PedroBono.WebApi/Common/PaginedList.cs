using Microsoft.EntityFrameworkCore;

namespace Ambev.Test.PedroBono.WebApi.Common
{
    public class PaginatedList<T> : List<T>
    {

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
