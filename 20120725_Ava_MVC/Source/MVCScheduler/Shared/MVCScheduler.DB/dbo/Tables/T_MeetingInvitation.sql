CREATE TABLE [dbo].[T_MeetingInvitation] (
    [ID]            UNIQUEIDENTIFIER NOT NULL,
    [MeetingID]     UNIQUEIDENTIFIER NOT NULL,
    [InviteeUserID] UNIQUEIDENTIFIER NOT NULL,
    [AnswerStatus]  INT              CONSTRAINT [DF_T_MeetingInvitation_AnswerStatus] DEFAULT ((1)) NOT NULL,
    [AnswerDate]    DATETIME         NULL,
    [Timestamp]     ROWVERSION       NOT NULL,
    CONSTRAINT [PK_T_MeetingInvitation] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_MeetingInvitation_M_AppUser] FOREIGN KEY ([InviteeUserID]) REFERENCES [dbo].[M_AppUser] ([ID]),
    CONSTRAINT [FK_T_MeetingInvitation_T_Meeting] FOREIGN KEY ([MeetingID]) REFERENCES [dbo].[T_Meeting] ([ID])
);

