CREATE TABLE [dbo].[Aftesite] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Emri]           NVARCHAR (MAX)   NOT NULL,
    [UserId]         NVARCHAR (450)   NOT NULL,
    [InstitucioniId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Aftesite] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Aftesite_Institucioni_InstitucioniId] FOREIGN KEY ([InstitucioniId]) REFERENCES [dbo].[Institucioni] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Aftesite_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Aftesite_InstitucioniId]
    ON [dbo].[Aftesite]([InstitucioniId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Aftesite_UserId]
    ON [dbo].[Aftesite]([UserId] ASC);

