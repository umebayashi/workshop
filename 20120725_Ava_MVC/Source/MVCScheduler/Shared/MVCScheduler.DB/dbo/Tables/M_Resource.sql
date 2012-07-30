CREATE TABLE [dbo].[M_Resource] (
    [ID]             UNIQUEIDENTIFIER NOT NULL,
    [Code]           NVARCHAR (50)    NOT NULL,
    [Name]           NVARCHAR (100)   NOT NULL,
    [ResourceTypeID] UNIQUEIDENTIFIER NOT NULL,
    [Timestamp]      ROWVERSION       NOT NULL,
    CONSTRAINT [PK_M_Resource] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_M_Resource_M_ResourceType] FOREIGN KEY ([ResourceTypeID]) REFERENCES [dbo].[M_ResourceType] ([ID])
);

