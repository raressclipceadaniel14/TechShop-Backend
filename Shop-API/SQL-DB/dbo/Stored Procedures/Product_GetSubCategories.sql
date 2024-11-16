CREATE PROCEDURE Product_GetSubCategories
	@categroyId INT
AS
BEGIN
    SELECT
		Id,
		Name,
		CategoryId
	FROM Subcategory
	WHERE CategoryId = @categroyId
END