CREATE TABLE [dbo].[M_AppUser] (
    [ID]           UNIQUEIDENTIFIER NOT NULL,
    [Code]         NVARCHAR (50)    NOT NULL,
    [Name]         NVARCHAR (100)   NOT NULL,
    [SystemUserID] UNIQUEIDENTIFIER NULL,
    [Timestamp]    ROWVERSION       NOT NULL,
    CONSTRAINT [PK_M_AppUser] PRIMARY KEY CLUSTERED ([ID] ASC)
);

