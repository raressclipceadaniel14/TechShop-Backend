
  CREATE PROCEDURE PreOrder_Delete
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM PreOrder
    WHERE UserId = @UserId;
END