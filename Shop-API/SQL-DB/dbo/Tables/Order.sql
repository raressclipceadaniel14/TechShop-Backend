CREATE TABLE [dbo].[Order] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Address]         NVARCHAR (MAX) NOT NULL,
    [PlacementDate]   DATETIME       NOT NULL,
    [UserId]          INT            NOT NULL,
    [OrderStatusId]   INT            NOT NULL,
    [PaymentMethodId] INT            NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Order] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_Order_Order1] FOREIGN KEY ([Id]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_Order_PaymentMethod] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethod] ([Id])
);

