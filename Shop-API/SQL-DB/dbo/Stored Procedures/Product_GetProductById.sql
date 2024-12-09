CREATE PROCEDURE [dbo].[Product_GetProductById]
    @ProductId INT
AS
BEGIN
    SELECT 
        Id,
        Name,
        Description,
        Price,
        SubCategoryId,
        ProviderId,
        Picture,
		Stock
    FROM 
        Product
    WHERE 
        Id = @ProductId;
END