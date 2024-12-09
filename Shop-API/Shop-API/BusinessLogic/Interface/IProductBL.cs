using Shop_API.Models.Product;

namespace Shop_API.BusinessLogic.Interface
{
    public interface IProductBL
    {
        Task DeleteProductsAsync(int productId);
        Task<List<CategoryModel>> GetCategoriesAsync();
        Task<CategoryModel> GetCategoryBySubcategory(int subCategoryId);
        Task<ProductModel> GetProductByIdAsync(int productId);
        Task<List<ProductModel>> GetProductsAsync(GetProductModelRequest request);
        Task<List<CategoryModel>> GetSubCategoriesAsync(int categroyId);
        Task<SubcategoryModel> GetSubcategoryById(int subCategoryId);
        Task ModifyStock(StockUpdateModel stockUpdate);
        Task SaveProductsAsync(SaveProductRequest request);
        Task UpdateProductsAsync(ProductModel request);
    }
}
