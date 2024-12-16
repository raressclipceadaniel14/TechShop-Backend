CREATE PROCEDURE [dbo].[OrderProduct_GetOrders]
AS
BEGIN
    -- Retrieve orders and their associated products
    SELECT
        o.Id AS Id,
        o.Address AS Address,
        o.PlacementDate AS PlacementDate,
        u.FirstName AS UserFirstName,
        u.LastName AS UserLastName,
        u.Email AS UserEmail,
        os.Name AS OrderStatus,
        pm.Name AS PaymentMethod
    FROM [Order] o
    LEFT JOIN [User] u ON o.UserId = u.Id
    LEFT JOIN OrderStatus os ON o.OrderStatusId = os.Id
    LEFT JOIN PaymentMethod pm ON o.PaymentMethodId = pm.Id
    ORDER BY o.PlacementDate DESC
END;