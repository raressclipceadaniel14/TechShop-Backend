CREATE PROCEDURE [dbo].[Order_Create]
    @Address NVARCHAR(MAX),
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [Order] (Address, PlacementDate, UserId, OrderStatusId, PaymentMethodId)
    VALUES (@Address, GETDATE(), @UserId, 1, 1);

	SELECT SCOPE_IDENTITY() AS OrderId;
END