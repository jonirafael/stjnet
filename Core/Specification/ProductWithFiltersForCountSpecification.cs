using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
            : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.FactoryId.HasValue || x.ProductFactoryId == productParams.FactoryId) &&
            (!productParams.CategoryId.HasValue || x.ProductCategoryId == productParams.CategoryId) &&
            x.isEnabled == true)
        {
        }
    }
}