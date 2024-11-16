CREATE PROCEDURE Auth_SaveUser
    @Email NVARCHAR(255),
    @Password NVARCHAR(255),
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100)
AS
BEGIN
    INSERT INTO [User] (Email, Password, FirstName, LastName, RoleId)
    VALUES (@Email, @Password, @FirstName, @LastName, 1);
END