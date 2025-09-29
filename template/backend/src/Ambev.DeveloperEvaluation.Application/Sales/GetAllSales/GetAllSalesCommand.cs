using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    /// <summary>
    /// Request model to get all sale list
    /// </summary>
    public class GetAllSalesCommand : IRequest<IQueryable<GetAllSalesResult>>
    {
    }
}
