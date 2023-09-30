using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductFactory> _productFactoryRepo;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductFactory> productFactoryRepo, 
            IGenericRepository<ProductCategory> productCategoryRepo,IMapper mapper)
        {
            this._mapper = mapper;
            this._productCategoryRepo = productCategoryRepo;
            this._productFactoryRepo = productFactoryRepo;
            this._productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithFactoriesAndCategoriesSpecification();

            var products = await _productRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithFactoriesAndCategoriesSpecification(id);
            
            var product = await _productRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Product,ProductToReturnDto>(product);
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