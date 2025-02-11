namespace Ambev.Test.PedroBono.WebApi.Common
{
    public class PaginatedResponse<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public List<T>? Data { get; set; }
    }
}
