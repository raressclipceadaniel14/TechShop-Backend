CREATE PROCEDURE [dbo].[Product_SaveProduct]
    @Name NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @Price INT,
    @SubCategoryId INT,
    @ProviderId INT,
    @Picture NVARCHAR(MAX),
	@Stock INT
AS
BEGIN
    INSERT INTO Product (Name, Description, Price, Stock, SubCategoryId, ProviderId, Picture)
    VALUES (@Name, @Description, @Price, @Stock, @SubCategoryId, @ProviderId, @Picture);
END