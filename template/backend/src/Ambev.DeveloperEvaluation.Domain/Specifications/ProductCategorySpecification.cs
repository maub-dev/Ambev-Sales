using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications
{
    public class ProductCategorySpecification : ISpecification<Product>
    {
        private readonly string _category;
        public ProductCategorySpecification(string category)
        {
            _category = category;
        }
        public bool IsSatisfiedBy(Product product)
        {
            return product.Category == _category;
        }
    }
}
