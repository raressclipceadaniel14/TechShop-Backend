  CREATE PROCEDURE Product_ModifyStock
    @ProductID INT,       -- The ID of the product to update
    @ModifyBy INT         -- The amount to increase or decrease stock by
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Product
    SET Stock = Stock + @ModifyBy
    WHERE Id = @ProductID;
END