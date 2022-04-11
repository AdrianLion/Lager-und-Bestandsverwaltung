CREATE TABLE [dbo].[Consumption]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Consumption_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
