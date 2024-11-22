CREATE PROCEDURE [dbo].[Product_GetProductById]
    @ProductId INT
AS
BEGIN
    SELECT 
        Id,
        Name,
        Description,
        Price,
        IsAvailable,
        SubCategoryId,
        ProviderId,
        Picture
    FROM 
        Product
    WHERE 
        Id = @ProductId;
END