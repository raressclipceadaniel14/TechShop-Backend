CREATE TABLE [dbo].[Subcategory] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [CategoryId] INT           NOT NULL,
    CONSTRAINT [PK_Subcategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Subcategory_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);

