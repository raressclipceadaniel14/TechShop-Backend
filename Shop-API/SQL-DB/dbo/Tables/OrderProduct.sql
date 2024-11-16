﻿CREATE TABLE [dbo].[OrderProduct] (
    [Id]        INT NOT NULL,
    [OrderId]   INT NOT NULL,
    [ProductId] INT NOT NULL,
    CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

