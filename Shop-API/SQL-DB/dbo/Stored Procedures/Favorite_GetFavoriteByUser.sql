  CREATE PROCEDURE Favorite_GetFavoriteByUser
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
        Favorite f ON p.Id = f.ProductId
    WHERE 
        f.UserId = @UserId;
END;