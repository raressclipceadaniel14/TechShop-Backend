CREATE PROCEDURE Product_SaveProduct
    @Name NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @Price INT,
    @IsAvailable BIT,
    @SubCategoryId INT,
    @ProviderId INT,
    @Picture NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Product (Name, Description, Price, IsAvailable, SubCategoryId, ProviderId, Picture)
    VALUES (@Name, @Description, @Price, @IsAvailable, @SubCategoryId, @ProviderId, @Picture);
END