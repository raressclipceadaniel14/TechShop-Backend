CREATE   PROCEDURE OrderProduct_GetProductsByOrderId
    @OrderId INT
AS
BEGIN
    -- Retrieve products associated with the given OrderId
    SELECT 
        p.Id AS Id,
        p.Name AS Name,
        p.Description AS Description,
        p.Price AS Price,
        p.SubCategoryId AS SubCategoryId,
        p.ProviderId AS ProviderId,
        p.Picture AS Picture,
        p.Stock AS Stock
    FROM Product p
    INNER JOIN OrderProduct op ON p.Id = op.ProductId
    WHERE op.OrderId = @OrderId;
END;