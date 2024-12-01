CREATE TABLE [dbo].[Order] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Address]         NVARCHAR (MAX) NOT NULL,
    [PlacementDate]   DATETIME       NOT NULL,
    [UserId]          INT            NOT NULL,
    [OrderStatusId]   INT            NOT NULL,
    [PaymentMethodId] INT            NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatus] ([Id]),
    CONSTRAINT [FK_Order_PaymentMethod] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethod] ([Id]),
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



