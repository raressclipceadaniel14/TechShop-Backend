CREATE PROCEDURE Product_GetCategories
AS
BEGIN
    SELECT
		Id,
		Name
	FROM Category
END