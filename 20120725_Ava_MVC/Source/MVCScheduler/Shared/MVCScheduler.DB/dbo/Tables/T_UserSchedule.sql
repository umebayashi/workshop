CREATE TABLE [dbo].[T_UserSchedule] (
    [ID]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (100)   NULL,
    [OwnerUserID] UNIQUEIDENTIFIER NOT NULL,
    [StartDate]   DATETIME         NOT NULL,
    [EndDate]     DATETIME         NOT NULL,
    [AllDay]      BIT              CONSTRAINT [DF_T_UserSchedule_AllDay] DEFAULT ((0)) NOT NULL,
    [Place]       NVARCHAR (100)   NULL,
    [MeetingID]   UNIQUEIDENTIFIER NULL,
    [Memo]        NVARCHAR (100)   NULL,
    [Timestamp]   ROWVERSION       NOT NULL,
    CONSTRAINT [PK_T_UserSchedule] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_UserSchedule_M_AppUser] FOREIGN KEY ([OwnerUserID]) REFERENCES [dbo].[M_AppUser] ([ID]),
    CONSTRAINT [FK_T_UserSchedule_T_Meeting] FOREIGN KEY ([MeetingID]) REFERENCES [dbo].[T_Meeting] ([ID])
);

