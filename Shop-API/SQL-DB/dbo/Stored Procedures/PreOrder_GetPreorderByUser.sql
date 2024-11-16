 CREATE PROCEDURE PreOrder_GetPreorderByUser
    @UserId INT
AS
BEGIN
    SELECT 
        p.Id,
        p.Name,
        p.Description,
        p.Price,
        p.IsAvailable,
        p.SubCategoryId,
        p.ProviderId,
        p.Picture
    FROM 
        Products p
    INNER JOIN 
        PreOrder po ON p.Id = po.ProductId
    WHERE 
        po.UserId = @UserId;
END;