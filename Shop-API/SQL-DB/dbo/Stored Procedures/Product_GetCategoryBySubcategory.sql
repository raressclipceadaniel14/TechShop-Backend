CREATE PROCEDURE Product_GetCategoryBySubcategory
    @SubcategoryId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.Id AS CategoryId,
        c.Name AS CategoryName
    FROM 
        Categories c
    INNER JOIN 
        Subcategories sc ON c.Id = sc.CategoryId
    WHERE 
        sc.Id = @SubcategoryId;
END