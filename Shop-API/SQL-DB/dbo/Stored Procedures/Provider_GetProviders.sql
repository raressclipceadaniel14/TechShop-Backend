CREATE PROCEDURE Provider_GetProviders
AS
BEGIN
    SELECT Id, Name, Address
    FROM Provider;
END;