CREATE   PROCEDURE [dbo].[Product_GetProducts]
    @CategoryId INT,
    @SubcategoryId INT
AS
BEGIN
    SELECT 
        p.Id,
        p.Name,
        p.Description,
        p.Price,
        p.SubCategoryId,
        p.ProviderId,
		p.Picture,
		p.Stock
    FROM 
        Product p
    WHERE
        -- Filter by SubcategoryId if it is provided
        (@SubcategoryId IS NOT NULL AND p.SubCategoryId = @SubcategoryId)
        OR
        -- Otherwise, filter by CategoryId in the Subcategory table
        (@SubcategoryId IS NULL AND p.SubCategoryId IN (
            SELECT s.Id 
            FROM Subcategory s 
            WHERE s.CategoryId = @CategoryId
        ))
END