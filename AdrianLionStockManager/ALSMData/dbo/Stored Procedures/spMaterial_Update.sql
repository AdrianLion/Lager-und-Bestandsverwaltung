CREATE PROCEDURE [dbo].[spMaterial_Update]
	@id INT,
	@name NVARCHAR(100),
	@description NVARCHAR(MAX),
	@quantityInStock INT,
	@createdDate DATETIME2(7)
AS
BEGIN
	UPDATE dbo.Material
	SET [Name] = @name,
		[Description] = @description,
		[QuantityInStock] = @quantityInStock,
		[CreatedDate] = @createdDate,
		[LastModified] = GETUTCDATE()
	WHERE [Id] = @id
END
