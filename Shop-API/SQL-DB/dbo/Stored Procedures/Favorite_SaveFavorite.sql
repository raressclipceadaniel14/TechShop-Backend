CREATE PROCEDURE [dbo].[Favorite_SaveFavorite]
    @UserId INT,
    @ProductId INT
AS
BEGIN
    INSERT INTO Favorite(UserId, ProductId)
    VALUES (@UserId, @ProductId);
END;