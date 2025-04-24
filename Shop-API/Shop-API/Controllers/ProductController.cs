using Microsoft.AspNetCore.Mvc;
using Shop_API.BusinessLogic.Interface;
using Shop_API.Models.Product;
using Shop_API.Services;

namespace Shop_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBL _productBL;

        public ProductController(IProductBL productBL)
        {
            this._productBL = productBL;
        }

        [HttpGet("search-specifications")]
        public ActionResult<List<SearchResultDto>> SearchSpecifications([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query cannot be empty");

            var luceneSearcher = new SpecificationSearcher();
            var results = luceneSearcher.Search(query);
            return Ok(results);
        }

        [HttpPost("build-spec-index")]
        public IActionResult BuildSpecIndex()
        {
            // Example data — replace with real specifications
            var specs = new List<SpecificationModel>
            {
                new SpecificationModel { Id = 1, Content = "Resolution: 1900x1200, RAM: 16GB" },
                new SpecificationModel { Id = 2, Content = "Screen size: 15.6 inch, CPU: Intel i5" },
                new SpecificationModel { Id = 3, Content = "Graphics: GTX 1050 Ti, Storage: 512GB SSD" }
            };

            var indexer = new SpecificationIndexer();
            indexer.IndexSpecifications(specs);

            return Ok("Index built successfully.");
        }


        [HttpGet("get-products")]
        public async Task<IEnumerable<ProductModel>> GetProductsAsync([FromQuery] GetProductModelRequest request)
        {
            var products = await _productBL.GetProductsAsync(request); 
            return products;
        }

        [HttpGet("get-product-by-id")]
        public async Task<ProductModel> GetProductByIdAsync([FromQuery] int productId)
        {
            var product = await _productBL.GetProductByIdAsync(productId);
            return product;
        }

        [HttpGet("get-categories")]
        public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
        {
            var categories = await _productBL.GetCategoriesAsync();
            return categories;
        }

        [HttpGet("get-subcategories")]
        public async Task<IEnumerable<CategoryModel>> GetSubCategoriesAsync([FromQuery] int categoryId)
        {
            var subCategories = await _productBL.GetSubCategoriesAsync(categoryId);
            return subCategories;
        }

        [HttpPost("save-product")]
        public async Task SaveProductsAsync([FromBody] SaveProductRequest request)
        {
            await _productBL.SaveProductsAsync(request);
        }


        [HttpPost("update-product")]
        public async Task UpdateProductsAsync([FromBody] ProductModel request)
        {
            await _productBL.UpdateProductsAsync(request);
        }

        [HttpPost("delete-product")]
        public async Task DeleteProductsAsync([FromQuery] int productId)
        {
            await _productBL.DeleteProductsAsync(productId);
        }

        [HttpGet("get-category-by-subcategory")]
        public async Task<CategoryModel> GetCategoryBySubcategory(int subCategoryId)
        {
            var category = await _productBL.GetCategoryBySubcategory(subCategoryId);
            return category;
        }

        [HttpGet("get-subcategory-by-id")]
        public async Task<SubcategoryModel> GetSubcategoryById(int subCategoryId)
        {
            var category = await _productBL.GetSubcategoryById(subCategoryId);
            return category;
        }

        [HttpPost("modify-stock")]
        public async Task ModifyStock(StockUpdateModel stockUpdate)
        {
            await _productBL.ModifyStock(stockUpdate);
        }
    }
}
