﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale
{
    /// <summary>
    /// Request model for cancelling a sale by ID
    /// </summary>
    public class CancelSaleRequest
    {
        /// <summary>
        /// The unique identifier of the sale to cancell
        /// </summary>
        public Guid Id { get; set; }
    }
}
