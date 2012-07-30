CREATE TABLE [dbo].[M_SystemUser] (
    [ID]                 UNIQUEIDENTIFIER NOT NULL,
    [UserID]             NVARCHAR (50)    NOT NULL,
    [Password]           NVARCHAR (100)   NOT NULL,
    [LastLogin]          DATETIME         NULL,
    [LastChangePassword] DATETIME         NULL,
    [LoginFailCount]     INT              DEFAULT ((0)) NOT NULL,
    [Timestamp]          ROWVERSION       NOT NULL,
    CONSTRAINT [PK_M_SystemUser] PRIMARY KEY CLUSTERED ([ID] ASC)
);

