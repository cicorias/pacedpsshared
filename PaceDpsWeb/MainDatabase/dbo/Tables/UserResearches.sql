CREATE TABLE [dbo].[UserResearch] (
    [Id]          INT            NOT NULL,
    [Title]       NCHAR (200)    NULL,
    [Description] NVARCHAR (50)  NULL,
    [UserId]      NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_UserResearches] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserResearch_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_UserResearch_AspNetUsers]
    ON [dbo].[UserResearch]([UserId] ASC);

