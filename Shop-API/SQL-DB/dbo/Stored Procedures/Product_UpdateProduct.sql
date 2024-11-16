CREATE PROCEDURE Product_UpdateProduct
    @Id INT,
    @Name NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @Price INT,
    @IsAvailable BIT,
    @SubCategoryId INT,
    @ProviderId INT,
    @Picture NVARCHAR(MAX)
AS
BEGIN
    UPDATE Product
    SET 
        Name = @Name,
        Description = @Description,
        Price = @Price,
        IsAvailable = @IsAvailable,
        SubCategoryId = @SubCategoryId,
        ProviderId = @ProviderId,
        Picture = @Picture
    WHERE 
        Id = @Id;
END