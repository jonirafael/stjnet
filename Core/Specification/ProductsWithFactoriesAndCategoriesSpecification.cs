using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification;

public class ProductsWithFactoriesAndCategoriesSpecification : BaseSpecification<Product>
{
    public ProductsWithFactoriesAndCategoriesSpecification(ProductSpecParams productParams)
        : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.FactoryId.HasValue || x.ProductFactoryId == productParams.FactoryId) &&
            (!productParams.CategoryId.HasValue || x.ProductCategoryId == productParams.CategoryId) &&
            x.isEnabled == true
        )
    {
        AddInclude(x => x.ProductCategory);
        AddInclude(x => x.ProductFactory);
        AddOrderBy(x => x.Name);
        ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

        if (!string.IsNullOrEmpty(productParams.Sort))
        {
            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.HNAPPN);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.HNAPPN);
                    break;
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }
        }
    }

    public ProductsWithFactoriesAndCategoriesSpecification(int id) : base(x => x.Id == id && x.isEnabled == true)
    {
        AddInclude(x => x.ProductCategory);
        AddInclude(x => x.ProductFactory);
    }

}
