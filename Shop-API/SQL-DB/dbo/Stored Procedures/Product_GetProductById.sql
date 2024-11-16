CREATE PROCEDURE Product_GetProductById
    @Id INT
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
        Id = @Id;
END