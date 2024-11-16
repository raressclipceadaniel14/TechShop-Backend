CREATE PROCEDURE PreOrder_SavePreOrder
    @UserId INT,
    @ProductId INT
AS
BEGIN
    INSERT INTO PreOrder (UserId, ProductId)
    VALUES (@UserId, @ProductId);
END;