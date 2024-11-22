CREATE PROCEDURE [dbo].[Product_GetCategoryBySubcategory]
    @SubCategoryId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.Id,
        c.Name
    FROM 
        Category c
    INNER JOIN 
        Subcategory sc ON c.Id = sc.CategoryId
    WHERE 
        sc.Id = @SubcategoryId;
END