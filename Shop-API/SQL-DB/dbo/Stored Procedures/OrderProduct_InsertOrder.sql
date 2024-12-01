 CREATE PROCEDURE OrderProduct_InsertOrder
    @OrderId INT,
    @Products ProductModelType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO OrderProduct (OrderId, ProductId)
    SELECT @OrderId, Id
    FROM @Products;
END