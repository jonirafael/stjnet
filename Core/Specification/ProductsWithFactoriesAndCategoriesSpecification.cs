using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification;

public class ProductsWithFactoriesAndCategoriesSpecification : BaseSpecification<Product>
{
    public ProductsWithFactoriesAndCategoriesSpecification() : base(x => x.isEnabled == true)
    {
        AddInclude(x => x.ProductCategory);
        AddInclude(x => x.ProductFactory);
    }

    public ProductsWithFactoriesAndCategoriesSpecification(int id) : base(x => x.Id == id && x.isEnabled == true)
    {
        AddInclude(x => x.ProductCategory);
        AddInclude(x => x.ProductFactory);
    }
}
