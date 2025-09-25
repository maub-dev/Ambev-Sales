namespace Ambev.DeveloperEvaluation.Application.Common.Pagination
{
    public class PaginatedResult
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
