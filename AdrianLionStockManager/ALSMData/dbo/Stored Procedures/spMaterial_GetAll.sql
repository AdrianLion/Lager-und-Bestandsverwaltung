CREATE PROCEDURE [dbo].[spMaterial_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Name], [Description], [QuantityInStock], [CreatedDate], [LastModified]
	FROM dbo.Material
	ORDER BY [Name];
END
