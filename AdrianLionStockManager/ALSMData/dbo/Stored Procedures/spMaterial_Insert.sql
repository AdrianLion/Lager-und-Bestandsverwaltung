CREATE PROCEDURE [dbo].[spMaterial_Insert]
	@name NVARCHAR(100),
	@description NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO dbo.Material VALUES(@name, @description,0,GETUTCDATE(),GETUTCDATE());
END

