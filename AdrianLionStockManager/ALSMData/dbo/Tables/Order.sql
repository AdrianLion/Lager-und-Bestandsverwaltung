CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
