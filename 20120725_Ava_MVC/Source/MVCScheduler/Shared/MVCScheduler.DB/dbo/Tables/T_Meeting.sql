CREATE TABLE [dbo].[T_Meeting] (
    [ID]             UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (100)   NOT NULL,
    [RoomResourceID] UNIQUEIDENTIFIER NOT NULL,
    [StartDate]      DATETIME         NOT NULL,
    [EndDate]        DATETIME         NOT NULL,
    [OwnerUserID]    UNIQUEIDENTIFIER NOT NULL,
    [Memo]           NVARCHAR (MAX)   NULL,
    [Timestamp]      ROWVERSION       NOT NULL,
    CONSTRAINT [PK_T_Meeting] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_Meeting_M_AppUser] FOREIGN KEY ([OwnerUserID]) REFERENCES [dbo].[M_AppUser] ([ID]),
    CONSTRAINT [FK_T_Meeting_M_Resource] FOREIGN KEY ([RoomResourceID]) REFERENCES [dbo].[M_Resource] ([ID])
);

