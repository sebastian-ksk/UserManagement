CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (100) NOT NULL,
    [LastName]     NVARCHAR (100) NOT NULL,
    [Email]        NVARCHAR (255) NOT NULL,
    [PhoneNumber]  NVARCHAR (20)  NULL,
    [Address]      NVARCHAR (500) NULL,
    [AreaId]       INT            NULL,
    [IsActive]     BIT            DEFAULT ((1)) NOT NULL,
    [CreatedDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Areas] FOREIGN KEY ([AreaId]) REFERENCES [dbo].[Areas] ([Id])
);

