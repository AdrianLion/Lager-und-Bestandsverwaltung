CREATE TABLE [dbo].[MaterialConsumption]
(
	[MaterialId] INT NOT NULL, 
    [ConsumptionId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [PK_MaterialConsumption] PRIMARY KEY ([MaterialId], [ConsumptionId])
)
