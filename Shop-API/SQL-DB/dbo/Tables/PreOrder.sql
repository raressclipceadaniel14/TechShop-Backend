CREATE TABLE [dbo].[PreOrder] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [ProductId] INT NOT NULL,
    [UserId]    INT NOT NULL,
    CONSTRAINT [PK_PreOrder] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PreOrder_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_PreOrder_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

