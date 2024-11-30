CREATE PROCEDURE [dbo].[Product_DeleteProduct]
    @productId INT
AS
BEGIN
    DELETE FROM Product
    WHERE Id = @productId;
END