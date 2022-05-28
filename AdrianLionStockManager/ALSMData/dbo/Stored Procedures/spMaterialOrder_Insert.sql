CREATE PROCEDURE [dbo].[spMaterialOrder_Insert]
	@orderId INT,
	@materialId int,
	@quantity int,
	@purchasePrice money
AS
BEGIN

	DECLARE @inserted table (Id INT);
	INSERT INTO Inventory (MaterialId,Quantity,PurchasePrice)
	OUTPUT INSERTED.Id INTO @inserted
	VALUES (@materialId, @quantity, @purchasePrice);
	DECLARE @inventoryId INT = (SELECT TOP 1 Id FROM @inserted);

	INSERT INTO MaterialOrder (OrderId,MaterialId,InventoryId,Quantity,PurchasePrice)
	VALUES (@orderId, @materialId, @inventoryId, @quantity, @purchasePrice);

	UPDATE Material
	SET QuantityInStock = QuantityInStock + @quantity
	WHERE Id = @materialId;
END