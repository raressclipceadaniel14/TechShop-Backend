CREATE PROCEDURE [dbo].[Product_UpdateProduct]
    @Id INT,
    @Name NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @Price INT,
    @SubCategoryId INT,
    @ProviderId INT,
    @Picture NVARCHAR(MAX),
	@Stock INT
AS
BEGIN
    UPDATE Product
    SET 
        Name = @Name,
        Description = @Description,
        Price = @Price,
        SubCategoryId = @SubCategoryId,
        ProviderId = @ProviderId,
        Picture = @Picture,
		Stock = @Stock
    WHERE 
        Id = @Id;
END