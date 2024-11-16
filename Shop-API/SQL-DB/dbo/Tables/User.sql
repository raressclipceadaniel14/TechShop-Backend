CREATE TABLE [dbo].[User] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Email]     NVARCHAR (50)  NOT NULL,
    [Password]  NVARCHAR (250) NOT NULL,
    [FirstName] NVARCHAR (50)  NOT NULL,
    [LastName]  NCHAR (10)     NOT NULL,
    [RoleId]    INT            NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
);



