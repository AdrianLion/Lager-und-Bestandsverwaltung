CREATE TABLE [dbo].[MaterialOrder]
(
	[OrderId] INT NOT NULL, 
    [MaterialId] INT NOT NULL, 
    [InventoryId] INT NOT NULL,
    [Quantity] INT NOT NULL,
    [PurchasePrice] MONEY NOT NULL,
    CONSTRAINT [PK_MaterialOrder] PRIMARY KEY ([OrderId], [MaterialId]), 
    CONSTRAINT [FK_MaterialOrder_Inventory] FOREIGN KEY ([InventoryId]) REFERENCES [Inventory]([Id]), 
    CONSTRAINT [FK_MaterialOrder_Material] FOREIGN KEY ([MaterialId]) REFERENCES [Material]([Id]), 
    CONSTRAINT [FK_MaterialOrder_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id])
    
)
