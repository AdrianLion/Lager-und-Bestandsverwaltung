CREATE PROCEDURE [dbo].[spInventory_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], MaterialId, Quantity, PurchasePrice, PurchaseDate
	FROM dbo.Inventory
	ORDER BY [Id];
END
