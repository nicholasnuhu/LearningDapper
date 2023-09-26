CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
BEGIN
	SELECT FirstName, LastName
	FROM [User]
	WHERE Id = @Id
END
