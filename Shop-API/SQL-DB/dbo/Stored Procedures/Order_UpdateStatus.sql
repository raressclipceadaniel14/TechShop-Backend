  CREATE PROCEDURE [dbo].[Order_UpdateStatus]
    @OrderId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [Order]
    SET OrderStatusId = 2
    WHERE Id = @OrderId;
END;