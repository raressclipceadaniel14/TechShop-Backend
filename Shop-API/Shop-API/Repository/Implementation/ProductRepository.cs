using api.Repositories.Implementations;
using Azure.Core;
using Dapper;
using Shop_API.BusinessLogic.Implementation;
using Shop_API.Models.Product;
using Shop_API.Repository.Interface;
using System.Data;

namespace Shop_API.Repository.Implementation
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private const string GetProductsSP = "Product_GetProducts";
        private const string GetCategoriesSP = "Product_GetCategories";
        private const string GetSubCategoriesSP = "Product_GetSubCategories";
        private const string SaveProductSP = "Product_SaveProduct";
        private const string UpdateProductSP = "Product_UpdateProduct";
        private const string DeleteProductSP = "Product_DeleteProduct";
        private const string GetProductSP = "Product_GetProductById";
        private const string GetCategoryBySubcategorySP = "Product_GetCategoryBySubcategory";
        private const string GetSubcategoryByIdSP = "Product_GetCategoryById";

        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryAsync<CategoryModel>(GetCategoriesSP,
                    commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<ProductModel>> GetProductsAsync(GetProductModelRequest request)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryAsync<ProductModel>(GetProductsSP,
                    param: new
                    {
                        request.SubcategoryId,
                        request.CategoryId,
                    },
                    commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<CategoryModel>> GetSubCategoriesAsync(int categroyId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryAsync<CategoryModel>(GetSubCategoriesSP,
                    param: new
                    {
                        categroyId
                    },
                    commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task SaveProductsAsync(SaveProductRequest request)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                await connection.ExecuteAsync(SaveProductSP,
                param: new
                {
                    request.Name,
                    request.Description,
                    request.Price,
                    request.IsAvailable,
                    request.SubCategoryId,
                    request.ProviderId,
                    request.Picture
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateProductsAsync(ProductModel request)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                await connection.ExecuteAsync(UpdateProductSP,
                param: new
                {
                    request.Id,
                    request.Name,
                    request.Description,
                    request.Price,
                    request.IsAvailable,
                    request.SubCategoryId,
                    request.ProviderId,
                    request.Picture
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteProductsAsync(int productId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                await connection.ExecuteAsync(DeleteProductSP,
                param: new
                {
                    productId
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<ProductModel> GetProductByIdAsync(int productId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryFirstOrDefaultAsync<ProductModel>(GetProductSP,
                    param: new
                    {
                        productId
                    },
                    commandType: CommandType.StoredProcedure));
            }
        }

        public async Task<CategoryModel> GetCategoryBySubcategory(int subCategoryId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryFirstOrDefaultAsync<CategoryModel>(GetCategoryBySubcategorySP,
                    param: new
                        {
                        subCategoryId
                    },
                    commandType: CommandType.StoredProcedure));
            }
        }

        public async Task<SubcategoryModel> GetSubcategoryById(int subCategoryId)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return (await connection.QueryFirstOrDefaultAsync<SubcategoryModel>(GetSubcategoryByIdSP,
                    param: new
                    {
                        subCategoryId
                    },
                    commandType: CommandType.StoredProcedure));
            }
        }
    }
}