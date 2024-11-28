CREATE TABLE [dbo].[Areas] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [AreaName]    NVARCHAR (100) NOT NULL,
    [IsActive]    BIT            DEFAULT ((1)) NOT NULL,
    [CreatedDate] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

