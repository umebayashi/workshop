CREATE TABLE [dbo].[T_ResourceReserve] (
    [ID]            UNIQUEIDENTIFIER NOT NULL,
    [Name]          NVARCHAR (100)   NOT NULL,
    [ResourceID]    UNIQUEIDENTIFIER NOT NULL,
    [StartDate]     DATETIME         NOT NULL,
    [EndDate]       DATETIME         NOT NULL,
    [ReserveUserID] UNIQUEIDENTIFIER NOT NULL,
    [Memo]          NVARCHAR (MAX)   NULL,
    [Timestamp]     ROWVERSION       NOT NULL,
    CONSTRAINT [PK_T_ResourceReserve] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_ResourceReserve_M_AppUser] FOREIGN KEY ([ReserveUserID]) REFERENCES [dbo].[M_AppUser] ([ID]),
    CONSTRAINT [FK_T_ResourceReserve_M_Resource] FOREIGN KEY ([ResourceID]) REFERENCES [dbo].[M_Resource] ([ID])
);

