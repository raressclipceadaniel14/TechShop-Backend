CREATE PROCEDURE Order_Get
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 *
    FROM [Order]
    WHERE UserId = @UserId
    ORDER BY PlacementDate DESC;
END