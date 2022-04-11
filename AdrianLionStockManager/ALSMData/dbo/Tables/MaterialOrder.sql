CREATE TABLE [dbo].[MaterialOrder]
(
	[OrderId] INT NOT NULL, 
    [MaterialId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [PK_MaterialOrder] PRIMARY KEY ([OrderId], [MaterialId])
)
