CREATE   PROCEDURE [dbo].[Auth_GetUserByEmail]
    @Email varchar(150)
AS
BEGIN
    SELECT Id, Email, Password, FirstName, LastName, RoleId
    FROM [User]
    WHERE [User].Email = @Email
END