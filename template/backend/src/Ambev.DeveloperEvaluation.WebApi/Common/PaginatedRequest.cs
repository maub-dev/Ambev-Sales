using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Common
{
    /// <summary>
    /// Represents a request with pagination filters.
    /// </summary>
    public class PaginatedRequest
    {
        /// <summary>
        /// Page number for pagination (default: 1)
        /// Must not be null or empty and greater than zero
        /// </summary>
        [FromQuery(Name = "_page")]
        public int Page { get; set; } = 1;

        /// <summary>
        /// Number of items per page (default: 10)
        /// Must not be null or empty and greater than zero
        /// </summary>
        [FromQuery(Name = "_size")]
        public int Size { get; set; } = 10;
    }
}
