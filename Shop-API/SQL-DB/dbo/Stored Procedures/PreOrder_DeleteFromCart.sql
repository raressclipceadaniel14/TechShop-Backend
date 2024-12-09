  CREATE PROCEDURE [dbo].[PreOrder_DeleteFromCart]
    @UserId INT,
	@ProductId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM PreOrder
    WHERE UserId = @UserId AND ProductId = @ProductId;
END