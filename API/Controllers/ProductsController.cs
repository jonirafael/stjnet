using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductFactory> _productFactoryRepo;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductFactory> productFactoryRepo,
            IGenericRepository<ProductCategory> productCategoryRepo, IMapper mapper)
        {
            this._mapper = mapper;
            this._productCategoryRepo = productCategoryRepo;
            this._productFactoryRepo = productFactoryRepo;
            this._productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
            [FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithFactoriesAndCategoriesSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await _productRepo.CountAsync(countSpec);

            var products = await _productRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,
                productParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithFactoriesAndCategoriesSpecification(id);

            var product = await _productRepo.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("factories")]
        public async Task<ActionResult<IReadOnlyList<ProductFactory>>> GetProductFatories()
        {
            return Ok(await _productFactoryRepo.ListAllAsync());
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetProductCategories()
        {
            return Ok(await _productCategoryRepo.ListAllAsync());
        }
    }
}