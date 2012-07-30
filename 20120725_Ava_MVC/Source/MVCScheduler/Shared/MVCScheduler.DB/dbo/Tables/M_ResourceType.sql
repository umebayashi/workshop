CREATE TABLE [dbo].[M_ResourceType] (
    [ID]        UNIQUEIDENTIFIER NOT NULL,
    [Code]      NVARCHAR (50)    NOT NULL,
    [Name]      NVARCHAR (100)   NOT NULL,
    [Timestamp] ROWVERSION       NOT NULL,
    CONSTRAINT [PK_M_ResourceType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

