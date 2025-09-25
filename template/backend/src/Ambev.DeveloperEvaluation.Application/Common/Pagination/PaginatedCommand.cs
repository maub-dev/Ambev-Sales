namespace Ambev.DeveloperEvaluation.Application.Common.Pagination
{
    /// <summary>
    /// Command for a list of Entities
    /// </summary>
    public class PaginatedCommand
    {
        /// <summary>
        /// Page number for pagination (default: 1)
        /// Must not be null or empty and greater than zero
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Number of items per page (default: 10)
        /// Must not be null or empty and greater than zero
        /// </summary>
        public int Size { get; set; } = 10;

        /// <summary>
        /// The sorting options for the list
        /// Ordering of results (e.g., "id desc, userId asc")
        /// </summary>
        public string Order { get; set; } = string.Empty;
    }
}
