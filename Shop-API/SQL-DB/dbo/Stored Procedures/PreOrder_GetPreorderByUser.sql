 CREATE PROCEDURE [dbo].[PreOrder_GetPreorderByUser]
    @UserId INT
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
    INNER JOIN 
        PreOrder po ON p.Id = po.ProductId
    WHERE 
        po.UserId = @UserId;
END;