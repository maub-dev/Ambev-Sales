using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts
{
    /// <summary>
    /// Request model to get all cart list
    /// </summary>
    public class GetAllCartsCommand : IRequest<IQueryable<GetAllCartsResult>>
    {
    }
}
