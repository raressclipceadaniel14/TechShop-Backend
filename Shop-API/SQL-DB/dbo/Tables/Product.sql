CREATE TABLE [dbo].[Product] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50)  NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [Price]         INT            NOT NULL,
    [IsAvailable]   BIT            NOT NULL,
    [SubcategoryId] INT            NOT NULL,
    [ProviderId]    INT            NOT NULL,
    [Picture]       VARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_Provider] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[Provider] ([Id]),
    CONSTRAINT [FK_Product_Subcategory] FOREIGN KEY ([SubcategoryId]) REFERENCES [dbo].[Subcategory] ([Id])
);



